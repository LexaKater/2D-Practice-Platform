using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealKit healKit))
        {
            float healthAfterHeal = _health.CurrentHealth + healKit.Heal;

            if (_health.CurrentHealth == _health.MaxHealth)
                return;

            if (healthAfterHeal > _health.MaxHealth)
            {
                float heal = healthAfterHeal - _health.MaxHealth;

                _health.TakeHeal(heal);
                Destroy(collision.gameObject);
            }
            else
            {
                _health.TakeHeal(healKit.Heal);
                Destroy(collision.gameObject);
            }
        }
    }
}