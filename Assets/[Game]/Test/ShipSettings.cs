using UnityEngine;

namespace _Game_.Test
{
    [CreateAssetMenu(fileName = "ShipSettings", menuName = "ShipSettings", order = 0)]
    public class ShipSettings : ScriptableObject
    {
        [SerializeField] private float turnSpeed;
        [SerializeField] private float moveSpeed;
        [SerializeField] private bool useAi;

        public float TurnSpeed => turnSpeed;
        public float MoveSpeed => moveSpeed;
        public bool UseAi => useAi;
    }
}