using _Game_.Scripts.Managers;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Game_.Scripts.VirtualCamera
{
    public class CameraBrain : MonoBehaviour
    {
        public CinemachineBrain CinemachineBrain { get; private set; }

        private void Awake() => CinemachineBrain = GetComponent<CinemachineBrain>();

        private async void OnEnable()
        {
            await UniTask.WaitUntil(() => CameraManager.Instance);
            CameraManager.Instance.SetCameraBrain(this);
        }
    }
}