using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HitAnimation : MonoBehaviour
{
    private const string DamageTriger = nameof(DamageTriger);

    [SerializeField] private Health _health;

    private Animator _animator;

    private void Start() => _animator = GetComponent<Animator>();

    private void OnEnable() => _health.HealthDecreased += PlayAnimation;

    private void OnDisable() => _health.HealthDecreased -= PlayAnimation;

    private void PlayAnimation() => _animator.SetTrigger(DamageTriger);
}