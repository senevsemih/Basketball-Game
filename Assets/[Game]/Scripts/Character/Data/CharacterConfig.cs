using UnityEngine;

namespace _Game_.Scripts.Character.Data
{
    [CreateAssetMenu(fileName = "Player Config", menuName = "Game/Player Config", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [Header("Movement")] [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float rimDotValue;
        [Header("Animation")] [SerializeField] private float moveThreshold;

        public float MoveSpeed => moveSpeed;
        public float RotateSpeed => rotateSpeed;
        public float MoveThreshold => moveThreshold;
        public float RimDotValue => rimDotValue;
    }
}