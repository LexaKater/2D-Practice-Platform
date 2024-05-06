using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HitAnimation : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Animator _animator;

    public readonly int DamageTriger = Animator.StringToHash(nameof(DamageTriger));

    private void Start() => _animator = GetComponent<Animator>();

    private void OnEnable() => _health.HealthDecreased += PlayAnimation;

    private void OnDisable() => _health.HealthDecreased -= PlayAnimation;

    private void PlayAnimation() => _animator.SetTrigger(DamageTriger);
}