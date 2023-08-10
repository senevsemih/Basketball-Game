using System;
using System.Collections.Generic;
using System.Linq;
using _Game_.Scripts.VirtualCamera;
using _Game_.Scripts.VirtualCamera.Interfaces;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Game_.Scripts.Managers
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private readonly List<ICameraTarget> _cameraTargets = new();
        private readonly List<IVirtualCamera> _virtualCameras = new();

        private const int DEFAULT_PRIORITY_VALUE = 10;
        private const int ACTIVE_PRIORITY_VALUE = 11;

        private CameraBrain CameraBrain { get; set; }
        private IVirtualCamera CurrentActiveCamera { get; set; }

        private void OnEnable() => ResetLists();
        private void OnDisable() => ResetLists();

        public void SetCameraBrain(CameraBrain cameraBrain) => CameraBrain = cameraBrain;

        public void AddCamera(IVirtualCamera virtualCamera)
        {
            if (!_virtualCameras.Contains(virtualCamera))
            {
                _virtualCameras.Add(virtualCamera);
            }
        }

        public void RemoveCamera(IVirtualCamera virtualCamera)
        {
            if (_virtualCameras.Contains(virtualCamera))
            {
                _virtualCameras.Remove(virtualCamera);
            }
        }

        public void AddCameraTarget(ICameraTarget cameraTarget)
        {
            if (!_cameraTargets.Contains(cameraTarget))
            {
                _cameraTargets.Add(cameraTarget);
            }
        }

        public void RemoveCameraTarget(ICameraTarget cameraTarget)
        {
            if (_cameraTargets.Contains(cameraTarget))
            {
                _cameraTargets.Remove(cameraTarget);
            }
        }

        public async void ActivateCamera(IVirtualCamera virtualCamera, float blendTime)
        {
            if (CurrentActiveCamera == virtualCamera) return;

            await UniTask.WaitUntil(() => CameraBrain);
            CameraBrain.CinemachineBrain.m_DefaultBlend =
                new CinemachineBlendDefinition(
                    CinemachineBlendDefinition.Style.EaseInOut,
                    blendTime);

            virtualCamera.Camera.Priority = ACTIVE_PRIORITY_VALUE;
            foreach (var cameraBase in _virtualCameras.Where(cameraBase => cameraBase != virtualCamera))
            {
                cameraBase.Camera.Priority = DEFAULT_PRIORITY_VALUE;
            }

            CurrentActiveCamera = virtualCamera;
        }

        public ICameraTarget GetCameraTarget(Type type)
        {
            var targets = _cameraTargets.ToArray();
            var target = Array.Find(targets, cameraTarget => cameraTarget.GetType().IsAssignableFrom(type));

            return target;
        }

        private void ResetLists()
        {
            _cameraTargets.Clear();
            _virtualCameras.Clear();
        }
    }
}