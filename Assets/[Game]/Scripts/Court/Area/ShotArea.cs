using _Game_.Scripts.Character.Components;
using _Game_.Scripts.Court.Area.Enums;
using _Game_.Scripts.Court.Area.Interface;
using UnityEngine;

namespace _Game_.Scripts.Court.Area
{
    public class ShotArea : MonoBehaviour, IArea
    {
        [SerializeField] private ParticleSystem highlightParticle;
        [Space, SerializeField] private CourtAreasTypes courtAreaTypes;

        public CourtAreasTypes CourtAreaType => courtAreaTypes;

        private void OnEnable() => CharacterEvents.OnCourtAreaUpdated.AddListener(HighlightCheck);
        private void OnDisable() => CharacterEvents.OnCourtAreaUpdated.RemoveListener(HighlightCheck);

        private void HighlightCheck(CourtAreasTypes courtAreaType)
        {
            if (CourtAreaType == courtAreaType)
            {
                HighlightActivate();
            }
            else
            {
                HighlightInactivate();
            }
        }

        public void HighlightActivate() => highlightParticle.Play();
        public void HighlightInactivate() => highlightParticle.Stop();
    }
}