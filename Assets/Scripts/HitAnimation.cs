using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HitAnimation : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Animator _animator;
    private string _trigerName = "TakeDamage";

    private void Start() => _animator = GetComponent<Animator>();

    private void OnEnable() => _health.HealthChanged += PlayAnimation;

    private void OnDisable() => _health.HealthChanged += PlayAnimation;

    private void PlayAnimation() => _animator.SetTrigger(_trigerName);
}