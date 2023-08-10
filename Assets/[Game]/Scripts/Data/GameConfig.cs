using UnityEngine;

namespace _Game_.Scripts.Data
{
    [CreateAssetMenu(fileName = "Game Config", menuName = "Game/Game Config", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [Header("Object Follower")] [SerializeField]
        private float followSpeed;

        [SerializeField] private float shotAreaLerpDistanceRate;

        public float FollowSpeed => followSpeed;
        public float DistanceRate => shotAreaLerpDistanceRate;
    }
}