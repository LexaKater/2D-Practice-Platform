using UnityEngine;
using UnityEngine.UI;

public class HealthButtons : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Button _buttonDamage;
    [SerializeField] private Button _buttonHeal;
    [SerializeField] private float _damage = 5;
    [SerializeField] private float _heal = 10;

    private void Awake()
    {
        _buttonDamage.onClick.AddListener(Attack);
        _buttonHeal.onClick.AddListener(Heal);
    }

    private void Attack() => _health.TakeDamage(_damage);

    private void Heal() => _health.TakeHeal(_heal);
}
