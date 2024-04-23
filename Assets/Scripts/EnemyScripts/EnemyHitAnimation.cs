using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyHitAnimation : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Animator _enemyAnimator;
    private string _trigerName = "TakeDamage";

    private void Start() => _enemyAnimator = GetComponent<Animator>();

    private void OnEnable() => _health.HealthChanged += PlayAnimation;

    private void OnDisable() => _health.HealthChanged += PlayAnimation;

    private void PlayAnimation() => _enemyAnimator.SetTrigger(_trigerName);
}