using UnityEngine.UI;
using UnityEngine;

public class HealthViewSlider : MonoBehaviour , ISliderShiftable
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthSlider;

    private void Start() => _healthSlider.value = _health.GetMaxHealth();

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

    public void ShiftSlider() => _healthSlider.value = _health.CurrentHealth;
}