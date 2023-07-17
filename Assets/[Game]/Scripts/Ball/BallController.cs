using System;
using UnityEngine;

namespace _Game_.Scripts.Ball
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
        }
    }
}