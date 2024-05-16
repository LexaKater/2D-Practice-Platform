using UnityEngine.UI;
using UnityEngine;

public class HealthViewSlider : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthSlider;

    private void Start() => _healthSlider.value = _health.GetMaxHealth();

    private void OnEnable()
    {
        _health.HealthDecreased += ShiftHelthSlider;
        _health.HealthIncreased += ShiftHelthSlider;
    }

    private void OnDisable()
    {
        _health.HealthDecreased -= ShiftHelthSlider;
        _health.HealthIncreased -= ShiftHelthSlider;
    }

    private void ShiftHelthSlider() => _healthSlider.value = _health.CurrentHealth;
}