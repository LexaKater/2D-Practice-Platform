using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _minHealth = 0;

    public event Action HealthDecreased;
    public event Action HealthIncreased;
    public event Action OwnerDied;

    public float CurrentHealth { get; private set; }

    private void Awake() => CurrentHealth = _maxHealth;

    public float GetMaxHealth() => _maxHealth;

    public void TakeHeal(HealKit healKit)
    {
        if (CurrentHealth == _maxHealth)
            return;

        CurrentHealth += healKit.Heal;
        CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, _maxHealth);

        Destroy(healKit.gameObject);

        HealthIncreased?.Invoke();
    }

    public void TakeHeal(float heal)
    {
        if (CurrentHealth == _maxHealth)
            return;

        CurrentHealth += heal;
        CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, _maxHealth);

        HealthIncreased?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            if (CurrentHealth > 0)
            {
                CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, CurrentHealth - damage);
                HealthDecreased?.Invoke();
            }

            if (CurrentHealth <= 0)
                OwnerDied?.Invoke();
        }
    }
}