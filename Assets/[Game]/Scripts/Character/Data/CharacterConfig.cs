using UnityEngine;

namespace _Game_.Scripts.Character.Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/Config", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _moveTreshold;
        public float MoveSpeed => _moveSpeed;
        public float RotateSpeed => _rotateSpeed;
        public double MoveThreshold => _moveTreshold;
    }
}