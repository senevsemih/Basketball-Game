using _Game_.Scripts.Managers;
using Cinemachine;
using UnityEngine;

namespace _Game_.Scripts.VirtualCamera
{
    public class CameraBrain : MonoBehaviour
    {
        public CinemachineBrain CinemachineBrain { get; private set; }

        private void Awake() => CinemachineBrain = GetComponent<CinemachineBrain>();

        private void OnEnable()
        {
            if (CameraManager.Instance == null) return;
            CameraManager.Instance.SetCameraBrain(this);
        }
    }
}