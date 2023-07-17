using System;
using _Game_.Scripts.Character.Other.Interaction;
using _Game_.Scripts.Court.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game_.Scripts.Character.Data
{
    [Serializable]
    public class CharacterData
    {
        public CharacterConfig Config;

        [ShowInInspector, ReadOnly] public bool HasBall { get; set; }
        [ShowInInspector, ReadOnly] public bool IsMovementActive { get; set; }
        [ShowInInspector, ReadOnly] public CourtAreas CurrentCourtArea { get; set; }
        [ShowInInspector, ReadOnly] public RadarInteraction RadarInteraction { get; set; }

        public Vector3 LastDirection { get; set; }
    }
}