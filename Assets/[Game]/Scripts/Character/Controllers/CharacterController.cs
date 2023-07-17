using _Game_.Scripts.Character.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game_.Scripts.Character.Controllers
{
    public class CharacterController : MonoBehaviour
    {
        public CharacterData Data;
        private CharacterEvents _events;

        private void Awake()
        {
            _events = GetComponent<CharacterEvents>();
        }

        private void Start()
        {
            _events.OnInitialized?.Invoke(Data);
        }

        [Button]
        private void MovementActivate()
        {
            Data.HasBall = true;
            _events.OnMovementActivated?.Invoke();
        }
    }
}