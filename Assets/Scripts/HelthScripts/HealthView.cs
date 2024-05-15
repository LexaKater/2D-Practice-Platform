using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _healthView;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _smoothlyHealthSlider;

    private float _maxHealth;
    private Coroutine _coroutine;

    private void Start()
    {
        _maxHealth = _health.GetMaxHealth();

        ShowHealthText();

        _healthSlider.value = _maxHealth;
        _smoothlyHealthSlider.value = _maxHealth;
    }

    private void OnEnable()
    {
        _health.HealthDecreased += ShowHealthText;
        _health.HealthIncreased += ShowHealthText;

        _health.HealthDecreased += ShiftHelthSlider;
        _health.HealthIncreased += ShiftHelthSlider;

        _health.HealthDecreased += SartSmoothlyShifting;
        _health.HealthIncreased += SartSmoothlyShifting;
    }

    private void OnDisable()
    {
        _health.HealthDecreased -= ShowHealthText;
        _health.HealthIncreased -= ShowHealthText;

        _health.HealthDecreased -= ShiftHelthSlider;
        _health.HealthIncreased -= ShiftHelthSlider;

        _health.HealthDecreased -= SartSmoothlyShifting;
        _health.HealthIncreased -= SartSmoothlyShifting;
    }

    private void ShowHealthText() => _healthView.text = $"{_health.CurrentHealth} | {_maxHealth}";

    private void ShiftHelthSlider() => _healthSlider.value = _health.CurrentHealth;

    private void SartSmoothlyShifting()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        StartCoroutine(ShiftSmootlyHealthSlider());
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
