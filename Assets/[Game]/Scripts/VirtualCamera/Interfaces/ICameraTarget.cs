using UnityEngine;

namespace _Game_.Scripts.VirtualCamera.Interfaces
{
    public interface ICameraTarget
    {
        public Transform Transform { get; }

        void SubToCamera();
        void UnSubToCamera();
    }
}