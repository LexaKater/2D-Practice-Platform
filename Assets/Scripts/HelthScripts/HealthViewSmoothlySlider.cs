using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewSmoothlySlider : MonoBehaviour, ISliderShiftable
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _smoothlyHealthSlider;
    [SerializeField, Range(0, 10)] private float _delay = 0.02f;
    [SerializeField, Range(0, 10)] private float _speed = 0.4f;

    private Coroutine _coroutine;

    private void Start() => _smoothlyHealthSlider.value = _health.GetMaxHealth();

    private void OnEnable()
    {
        _health.HealthDecreased += ShiftSlider;
        _health.HealthIncreased += ShiftSlider;
    }

    private void OnDisable()
    {
        _health.HealthDecreased -= ShiftSlider;
        _health.HealthIncreased -= ShiftSlider;
    }

    public void ShiftSlider()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ShiftSmoothlySlider());
    }

    private IEnumerator ShiftSmoothlySlider()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_smoothlyHealthSlider.value != _health.CurrentHealth)
        {
            _smoothlyHealthSlider.value = Mathf.MoveTowards(_smoothlyHealthSlider.value, _health.CurrentHealth, _speed);

            yield return wait;
        }
    }
}
