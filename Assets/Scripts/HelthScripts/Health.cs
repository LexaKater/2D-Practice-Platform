using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public event Action HealthChanged;
    public event Action OwnerDied;

    private void Start() => _currentHealth = _maxHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealKit healKit))
        {
            float healthAfterHeal = _currentHealth + healKit.Heal;

            if (_currentHealth == _maxHealth)
                return;

            if (healthAfterHeal > _maxHealth)
            {
                _currentHealth = _maxHealth;
                Destroy(collision.gameObject);
            }
            else
            {
                _currentHealth += healKit.Heal;
                Destroy(collision.gameObject);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke();
        }

        if (_currentHealth <= 0)
            OwnerDied?.Invoke();
    }
}
