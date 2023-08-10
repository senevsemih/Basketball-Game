using System;
using _Game_.Scripts.Managers;
using _Game_.Scripts.VirtualCamera.Interfaces;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Game_.Scripts.VirtualCamera.Base
{
    public abstract class VirtualCameraBase : MonoBehaviour, IVirtualCamera
    {
        private const float BLEND_DURATION = 1f;

        public ICameraTarget CameraTarget { get; set; }
        public CinemachineVirtualCamera Camera { get; private set; }

        private void Awake() => Camera = GetComponent<CinemachineVirtualCamera>();

        private void OnEnable()
        {
            if (CameraManager.Instance == null) return;
            CameraManager.Instance.AddCamera(this);
        }

        private void OnDisable()
        {
            if (CameraManager.Instance == null) return;
            CameraManager.Instance.RemoveCamera(this);
        }

        public virtual async void GetTarget(Type type)
        {
            await UniTask.WaitUntil(() => CameraManager.Instance.GetCameraTarget(type) != null);
            CameraTarget = CameraManager.Instance.GetCameraTarget(type);
            SetTargetValues(CameraTarget);
        }

        public virtual void ActivateCamera() => CameraManager.Instance.ActivateCamera(this, BLEND_DURATION);

        private void SetTargetValues(ICameraTarget cameraTarget)
        {
            Camera.Follow = cameraTarget.Transform;
            Camera.LookAt = cameraTarget.Transform;
        }
    }
}