using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth { get; private set; } = 100;
    public float CurrentHealth { get; private set; }

    public event Action HealthChanged;
    public event Action OwnerDied;

    private void Start() => CurrentHealth = MaxHealth;

    public void TakeHeal(float heal)
    {
        if (heal >= 0)
            CurrentHealth += heal;
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            if (CurrentHealth > 0)
            {
                float minHealth = 0;

                CurrentHealth = Mathf.Clamp(CurrentHealth, minHealth, CurrentHealth - damage);
                HealthChanged?.Invoke();
            }

            if (CurrentHealth <= 0)
                OwnerDied?.Invoke();
        }
    }
}
