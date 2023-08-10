using System.Collections;
using System.Collections.Generic;
using _Game_.Scripts.Court.Rim.Hoop.Interface;
using UnityEngine;

namespace _Game_.Scripts.Court.Rim.Hoop
{
    public class HoopController : MonoBehaviour
    {
        private HoopEvents _events;

        private Coroutine _counterResetRoutine;
        private WaitForSeconds _wfsCounterResetDelay;
        private const float RESET_DELAY = 1f;

        private readonly List<IHoopInteraction> _hoopInteractions = new();

        private void Awake() => _events = GetComponent<HoopEvents>();
        private void Start() => _wfsCounterResetDelay = new WaitForSeconds(RESET_DELAY);

        private void OnEnable() => _events.onInteractedWithBall.AddListener(InteractionCounter);
        private void OnDisable() => _events.onInteractedWithBall.RemoveListener(InteractionCounter);

        private void InteractionCounter(IHoopInteraction hoopInteraction)
        {
            if (!_hoopInteractions.Contains(hoopInteraction))
            {
                _hoopInteractions.Add(hoopInteraction);
            }

            if (_counterResetRoutine != null)
            {
                StopCoroutine(_counterResetRoutine);
            }

            _counterResetRoutine = StartCoroutine(CounterResetRoutine());
        }

        private IEnumerator CounterResetRoutine()
        {
            yield return _wfsCounterResetDelay;
            _hoopInteractions.Clear();
        }
    }
}