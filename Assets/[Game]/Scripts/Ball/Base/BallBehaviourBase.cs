using _Game_.Scripts.Ball.Components;
using _Game_.Scripts.Ball.Data;
using _Game_.Scripts.Ball.Interface;
using _Game_.Scripts.Other;
using UnityEngine;

namespace _Game_.Scripts.Ball.Base
{
    public abstract class BallBehaviourBase : IBallBehaviour
    {
        protected readonly BallData Data;
        protected readonly BallConfig Config;
        protected readonly BallEvents Events;

        protected BallBehaviourBase(
            BallData data,
            BallEvents events
        )
        {
            Data = data;
            Config = data.Config;
            Events = events;
        }

        public virtual void Activate()
        {
            Data.Transform.position = Data.LaunchPosition;
            Data.Rigidbody.position = Data.LaunchPosition;
        }

        public virtual void Execute()
        {
            Data.Rigidbody.isKinematic = false;
            Data.Rigidbody.angularVelocity = Extensions.GetRandomVector();

            Events.onLaunch?.Invoke();
        }

        public virtual void OnDestroy()
        {
        }

        protected Vector3 TargetPositionWithDeflection()
        {
            var randomX = Random.Range(Config.DeflectionRange.x, Config.DeflectionRange.y);
            var randomZ = Random.Range(Config.DeflectionRange.x, Config.DeflectionRange.y);

            var deflection = new Vector3(randomX, 0f, randomZ);

            return Data.TargetPosition + deflection;
        }
    }
}