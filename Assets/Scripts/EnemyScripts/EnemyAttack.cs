using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private TrigerZone _trigerZone;
    [SerializeField, Range(0f, 10f)] private float _rangeForAttack;
    [SerializeField, Range(0f, 10f)] private float _maxTimeForAttack;
    [SerializeField, Range(0f, 10f)] private float _damage;

    private float _currentTimeForAttack;
    private bool _isAttack = false;
    private Transform _target;

    private void Start() => _currentTimeForAttack = _maxTimeForAttack;

    private void Update() => FindEnemy();

    private void FindEnemy()
    {
        if (_trigerZone.Player == null)
        {
            _currentTimeForAttack = _maxTimeForAttack;
            _isAttack = false;

            return;
        }
        else
        {
            _target = _trigerZone.Player.transform;

            Vector2 distanceToPlayer = transform.position - _target.position;

            if (_trigerZone.Player.TryGetComponent(out Health health) || distanceToPlayer.x < _rangeForAttack)
            {
                Attack();

                if (_isAttack == false)
                    health.TakeDamage(_damage);
            }
        }
    }

    private void Attack()
    {
        if (_currentTimeForAttack >= 0)
        {
            _currentTimeForAttack -= Time.deltaTime;
            _isAttack = true;
        }
        else
        {
            _currentTimeForAttack = _maxTimeForAttack;
            _isAttack = false;
        }
    }
}