using System.Collections;
using UnityEngine;

public class HealthViewSmoothlySlider : SliderShifter
{
    [SerializeField, Range(0, 10)] private float _delay = 0.02f;
    [SerializeField, Range(0, 10)] private float _speed = 0.4f;

    private Coroutine _coroutine;

    protected override void ShiftSlider()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(StartShiftSmoothlySlider());
    }

    private IEnumerator StartShiftSmoothlySlider()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (HealthSlider.value != GetCurrentHealth())
        {
            HealthSlider.value = Mathf.MoveTowards(HealthSlider.value, GetCurrentHealth(), _speed);

            yield return wait;
        }
    }
}
