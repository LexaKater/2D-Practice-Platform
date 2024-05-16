using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewSmoothySlider : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _smoothlyHealthSlider;

    private Coroutine _coroutine;

    private void Start() => _smoothlyHealthSlider.value = _health.GetMaxHealth();

    private void OnEnable()
    {
        _health.HealthDecreased += SartSmoothlyShifting;
        _health.HealthIncreased += SartSmoothlyShifting;
    }

    private void OnDisable()
    {
        _health.HealthDecreased -= SartSmoothlyShifting;
        _health.HealthIncreased -= SartSmoothlyShifting;
    }

    private void SartSmoothlyShifting()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ShiftSmootlyHealthSlider());
    }

    private IEnumerator ShiftSmootlyHealthSlider()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        float valueTarget = _health.CurrentHealth;
        float valueSlider = _smoothlyHealthSlider.value;
        float speedShifting = 1f;
        float delay = 1f;

        for (float i = 0; i < delay; i += speedShifting * Time.deltaTime)
        {
            _smoothlyHealthSlider.value = Mathf.Lerp(valueSlider, valueTarget, i);

            yield return wait;
        }

        _smoothlyHealthSlider.value = valueTarget;
    }
}
