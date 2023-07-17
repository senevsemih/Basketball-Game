using UnityEngine;

namespace _Game_.Scripts.InputHandlers
{
    public interface IInput
    {
        void ReadInput();
        public Vector3 Direction { get; set; }
    }
}