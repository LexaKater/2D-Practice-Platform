using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealKit healKit))
            _health.TakeHeal(healKit);
    }
}