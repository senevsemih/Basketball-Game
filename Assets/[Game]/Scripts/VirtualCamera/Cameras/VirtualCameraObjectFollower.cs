using _Game_.Scripts.Other;
using _Game_.Scripts.VirtualCamera.Base;

namespace _Game_.Scripts.VirtualCamera.Cameras
{
    public class VirtualCameraObjectFollower : VirtualCameraBase
    {
        private void Start()
        {
            GetTarget(typeof(ObjectFollower));
            ActivateCamera();
        }
    }
}