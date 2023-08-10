using System;
using _Game_.Scripts.Ball.Behaviours;
using _Game_.Scripts.Ball.Components;
using _Game_.Scripts.Ball.Data;
using _Game_.Scripts.Ball.Enum;
using _Game_.Scripts.Ball.Interface;
using _Game_.Scripts.Character.Components;
using UnityEngine;

namespace _Game_.Scripts.Ball.Handlers
{
    public class BallBehaviourHandler : IBallHandler
    {
        private readonly BallData _data;
        private IBallBehaviour[] _behaviours;

        public BallBehaviourHandler(
            BallData data,
            BallEvents events)
        {
            _data = data;

            CreateBehaviours(
                new BallShotBehaviour(_data, events),
                new BallPassBehaviour(_data, events));

            CharacterEvents.OnLaunchBall.AddListener(LaunchSetup);
        }

        public void OnDestroy()
        {
            foreach (var behaviour in _behaviours)
            {
                behaviour.OnDestroy();
            }

            CharacterEvents.OnLaunchBall.RemoveListener(LaunchSetup);
        }

        private void CreateBehaviours(params IBallBehaviour[] behaviours) => _behaviours = behaviours;

        private void LaunchSetup(Vector3 launchPosition, Vector3 targetPosition, BallLaunchType launchType)
        {
            _data.LaunchPosition = launchPosition;
            _data.TargetPosition = targetPosition;

            var behaviourType = launchType switch
            {
                BallLaunchType.Pass => typeof(BallPassBehaviour),
                BallLaunchType.Shot => typeof(BallShotBehaviour),
                _ => throw new ArgumentOutOfRangeException()
            };

            var findBehaviour = Array.Find(
                _behaviours,
                behaviour => behaviour.GetType().IsAssignableFrom(behaviourType));

            findBehaviour?.Activate();
        }
    }
}