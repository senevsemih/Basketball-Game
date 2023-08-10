using System;
using _Game_.Scripts.Court.Area.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game_.Scripts.Character.Data
{
    [Serializable]
    public class CharacterData
    {
        [SerializeField] private CharacterConfig config;
        [Space, SerializeField] private GameObject ballGraphic;

        public CharacterConfig Config => config;
        public GameObject BallGraphic => ballGraphic;

        public Transform Transform { get; set; }
        public Rigidbody Rigidbody { get; set; }

        [ShowInInspector, ReadOnly] public bool HasBall { get; set; }
        [ShowInInspector, ReadOnly] public bool IsLookingToRim { get; set; }
        [ShowInInspector, ReadOnly] public bool IsMovementActive { get; set; }
        [ShowInInspector, ReadOnly] public bool IsBehaviourExecuting { get; set; }

        [ShowInInspector, ReadOnly] public float VelocityMagnitude { get; set; }

        [ShowInInspector, ReadOnly] public Vector3 ForwardDirection { get; set; }
        [ShowInInspector, ReadOnly] public Vector3 LastDirection { get; set; }
        [ShowInInspector, ReadOnly] public Vector3 BallPosition => BallGraphic.transform.position;

        [ShowInInspector, ReadOnly] public CourtAreasTypes CurrentCourtAreaType { get; set; }
    }
}