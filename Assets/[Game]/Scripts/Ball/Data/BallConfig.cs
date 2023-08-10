using UnityEngine;

namespace _Game_.Scripts.Ball.Data
{
    [CreateAssetMenu(fileName = "Ball Config", menuName = "Game/Ball Config", order = 0)]
    public class BallConfig : ScriptableObject
    {
        [Header("Pass")] [SerializeField] private float passForce;

        [Header("Shot")] [SerializeField] private float shotDuration;
        [SerializeField] private Vector2 shotHeightRange;
        [Space, SerializeField] private Vector2 deflectionRange;

        public float PassForce => passForce;
        public float ShotDuration => shotDuration;
        public Vector2 ShotHeightRange => shotHeightRange;
        public Vector2 DeflectionRange => deflectionRange;
    }
}