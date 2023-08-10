using System;
using _Game_.Scripts.Character.Components;
using _Game_.Scripts.Court.Area.Enums;
using _Game_.Scripts.Data;
using _Game_.Scripts.Interfaces;
using _Game_.Scripts.Managers;
using _Game_.Scripts.VirtualCamera.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace _Game_.Scripts.Other
{
    public class ObjectFollower : MonoBehaviour, ICameraTarget
    {
        [SerializeField] private GameConfig config;

        public static readonly UnityEvent<ITarget> OnTargetChanged = new();

        private ITarget _target;

        private bool _isActive;
        private bool _isShotArea;

        public Transform Transform => transform;

        private void Start() => _isActive = true;

        private void OnEnable()
        {
            OnTargetChanged.AddListener(OnTargetChange);
            CharacterEvents.OnCourtAreaUpdated.AddListener(OnCourtAreaUpdated);

            if (CameraManager.Instance != null)
            {
                SubToCamera();
            }
        }

        private void OnDisable()
        {
            OnTargetChanged.RemoveListener(OnTargetChange);
            CharacterEvents.OnCourtAreaUpdated.RemoveListener(OnCourtAreaUpdated);

            if (CameraManager.Instance != null)
            {
                UnSubToCamera();
            }
        }

        private void Update()
        {
            if (_isActive)
            {
                FollowTarget();
            }
        }

        private void OnTargetChange(ITarget newTarget) => _target = newTarget;

        private void OnCourtAreaUpdated(CourtAreasTypes areasTypes)
        {
            _isShotArea = areasTypes switch
            {
                CourtAreasTypes.PassArea => false,
                CourtAreasTypes.ShotArea => true,
                _ => throw new ArgumentOutOfRangeException(nameof(areasTypes), areasTypes, null)
            };
        }

        public void SubToCamera() => CameraManager.Instance.AddCameraTarget(this);
        public void UnSubToCamera() => CameraManager.Instance.RemoveCameraTarget(this);

        private void FollowTarget()
        {
            var targetPosition = _target.Position;
            var newTargetPosition = new Vector3(targetPosition.x, 0f, targetPosition.z);

            var target = _isShotArea
                ? Vector3.Lerp(newTargetPosition, GameManager.Instance.RimController.Position, config.DistanceRate)
                : newTargetPosition;

            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                config.FollowSpeed * Time.deltaTime);
        }

        private void OnDestroy() => _isActive = false;
    }
}