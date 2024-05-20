using UnityEngine;
using UnityEngine.UI;

public abstract class SliderShifter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider HealthSlider;

    private void Start() => HealthSlider.value = _health.GetMaxHealth();

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

    protected abstract void ShiftSlider();

    protected float GetCurrentHealth() => _health.CurrentHealth;
}