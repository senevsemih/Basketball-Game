using System;
using _Game_.Scripts.Character.Behaviours;
using _Game_.Scripts.Character.Components;
using _Game_.Scripts.Character.Data;
using _Game_.Scripts.Character.Interfaces;
using _Game_.Scripts.Court.Area.Enums;

namespace _Game_.Scripts.Character.Handlers
{
    public class CharacterBehaviourHandler : ICharacterHandler
    {
        private readonly CharacterData _data;
        private readonly CharacterEvents _events;

        private ICharacterBehaviour[] _behaviours;

        public CharacterBehaviourHandler(
            CharacterData data,
            CharacterEvents events)
        {
            _data = data;
            _events = events;

            CreateBehaviours(
                new PassBehaviour(_data, _events),
                new ShotBehaviour(_data, _events));

            _events.onBallReleased.AddListener(OnBallReleased);
            _events.onBehaviourExecuted.AddListener(OnBehaviourExecuted);
        }

        public void Tick()
        {
        }

        public void FixedTick()
        {
        }

        public void OnDestroy()
        {
            _events.onBallReleased.RemoveListener(OnBallReleased);
            _events.onBehaviourExecuted.RemoveListener(OnBehaviourExecuted);

            foreach (var behaviour in _behaviours)
            {
                behaviour.OnDestroy();
            }
        }

        private void CreateBehaviours(params ICharacterBehaviour[] behaviours) => _behaviours = behaviours;

        private void OnBallReleased()
        {
            if (!_data.HasBall) return;
            _data.IsBehaviourExecuting = true;

            var behaviourType = _data.CurrentCourtAreaType switch
            {
                CourtAreasTypes.PassArea => typeof(PassBehaviour),
                CourtAreasTypes.ShotArea => _data.IsLookingToRim
                    ? typeof(ShotBehaviour)
                    : typeof(PassBehaviour),
                _ => throw new ArgumentOutOfRangeException()
            };

            var findBehaviour = Array.Find(
                _behaviours,
                behaviour => behaviour.GetType().IsAssignableFrom(behaviourType));

            findBehaviour?.Activate();
        }

        private void OnBehaviourExecuted() => _data.IsBehaviourExecuting = false;
    }
}