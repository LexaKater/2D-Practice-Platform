using TMPro;
using UnityEngine;

public class HealthViewText : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _healthView;

    private float _maxHealth;

    private void Start()
    {
        _maxHealth = _health.GetMaxHealth();
        ShowHealthText();
    }

    private void OnEnable()
    {
        _health.HealthDecreased += ShowHealthText;
        _health.HealthIncreased += ShowHealthText;
    }

    private void OnDisable()
    {
        _health.HealthDecreased -= ShowHealthText;
        _health.HealthIncreased -= ShowHealthText;
    }

    private void ShowHealthText() => _healthView.text = $"{_health.CurrentHealth} | {_maxHealth}";
}