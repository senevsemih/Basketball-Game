using _Game_.Scripts.Interfaces;
using _Game_.Scripts.Managers;
using UnityEngine;

namespace _Game_.Scripts.Court.Rim
{
    public class RimController : MonoBehaviour, ITarget
    {
        [SerializeField] private Transform hoop;

        public Vector3 Position => hoop.position;

        private void Start() => GameManager.Instance.SetRimController(this);
    }
}