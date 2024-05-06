using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    private float _minHealth = 0;

    public event Action HealthDecreased;
    public event Action OwnerDied;

    private void Start() => _currentHealth = _maxHealth;

    public void TakeHeal(HealKit healKit)
    {
        if (_currentHealth == _maxHealth)
            return;

        _currentHealth += healKit.Heal;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);

        Destroy(healKit.gameObject);
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            if (_currentHealth > 0)
            {
                _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _currentHealth - damage);
                HealthDecreased?.Invoke();
            }

            if (_currentHealth <= 0)
                OwnerDied?.Invoke();
        }
    }
}