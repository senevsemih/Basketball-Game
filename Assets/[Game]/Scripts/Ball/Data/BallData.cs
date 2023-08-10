using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game_.Scripts.Ball.Data
{
    [Serializable]
    public class BallData
    {
        [SerializeField] private BallConfig config;

        public BallConfig Config => config;
        public Rigidbody Rigidbody { get; set; }
        public Transform Transform { get; set; }

        [ShowInInspector, ReadOnly] public Vector3 LaunchPosition { get; set; }
        [ShowInInspector, ReadOnly] public Vector3 TargetPosition { get; set; }
    }
}