using System.Collections.Generic;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Other.Interaction;
using UnityEngine;

namespace _Game_.Scripts.Character
{
    public class CharacterRadar : MonoBehaviour
    {
        private CharacterData _data;
        private CharacterEvents _events;

        private readonly List<RadarInteraction> _radarInteractions = new();

        private void Awake() => _events = GetComponentInParent<CharacterEvents>();

        private void OnEnable() => _events.OnInitialized.AddListener(OnInitialized);

        private void OnDisable() => _events.OnInitialized.RemoveListener(OnInitialized);

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent(out RadarInteraction interaction) || !_data.HasBall) return;
            AddRadarInteraction(interaction);
            CheckNearestRadarInteraction();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out RadarInteraction interaction) || !_data.HasBall) return;
            RemoveRadarInteraction(interaction);
        }

        private void OnInitialized(CharacterData data) => _data = data;

        private void AddRadarInteraction(RadarInteraction interaction)
        {
            if (!_radarInteractions.Contains(interaction))
            {
                _radarInteractions.Add(interaction);
            }
        }

        private void RemoveRadarInteraction(RadarInteraction interaction)
        {
            if (!_radarInteractions.Contains(interaction)) return;

            if (ReferenceEquals(interaction, _data.RadarInteraction))
            {
                _data.RadarInteraction.Unselected();
            }

            _radarInteractions.Remove(interaction);
        }

        private void CheckNearestRadarInteraction()
        {
            var maxDistance = 1000f;
            foreach (var radarInteraction in _radarInteractions)
            {
                var distance = Vector3.Distance(transform.position, radarInteraction.transform.position);

                if (!(distance < maxDistance)) continue;
                maxDistance = distance;

                if (_data.RadarInteraction != null && !ReferenceEquals(_data.RadarInteraction, radarInteraction))
                {
                    _data.RadarInteraction.Unselected();
                }

                _data.RadarInteraction = radarInteraction;
                _data.RadarInteraction.Selected();
            }
        }
    }
}