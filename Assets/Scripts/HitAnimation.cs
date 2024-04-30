using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HitAnimation : MonoBehaviour
{
    [SerializeField] private Health _health;

    public readonly int Triger = Animator.StringToHash(nameof(TakeDamage));

    private const string TakeDamage = nameof(TakeDamage);

    private Animator _animator;

    private void Start() => _animator = GetComponent<Animator>();

    private void OnEnable() => _health.HealthChanged += PlayAnimation;

    private void OnDisable() => _health.HealthChanged += PlayAnimation;

    private void PlayAnimation() => _animator.SetTrigger(Triger);
}