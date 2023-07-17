using _Game_.Scripts.Character.Behaviours;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game_.Scripts.Character.Controllers
{
    public class CharacterBehaviourController : MonoBehaviour
    {
        [ShowInInspector, ReadOnly] private CharacterData _data;
        [ShowInInspector, ReadOnly] private CharacterEvents _events;

        private IBehaviour[] _behaviours;

        private void Awake()
        {
            _events = GetComponent<CharacterEvents>();
        }

        private void OnEnable()
        {
            _events.OnInitialized.AddListener(OnInitialized);
        }

        private void OnDisable()
        {
            _events.OnInitialized.RemoveListener(OnInitialized);
        }

        private void OnInitialized(CharacterData data)
        {
            _data = data;

            CreateBehaviours(
                new CharacterPassBehaviour(_data, _events),
                new CharacterShootBehaviour(_data, _events));
        }


        private void CreateBehaviours(params IBehaviour[] behaviours)
        {
            _behaviours = behaviours;
        }

        [Button]
        private void ChangeBehaviourState(int value)
        {
            if (value == 0)
            {
                _behaviours[0].Activate();
            }
            else
            {
                _behaviours[1].Activate();
            }
        }

        private void OnDestroy()
        {
            foreach (var behaviour in _behaviours)
            {
                behaviour.OnDestroy();
            }
        }
    }
}