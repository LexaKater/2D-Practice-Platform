using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private PlayerSearcher _searcher;
    [SerializeField, Range(0f, 10f)] private float _rangeForAttack;
    [SerializeField, Range(0f, 10f)] private float _maxTimeForAttack;
    [SerializeField, Range(0f, 10f)] private float _damage;

    private float _currentTimeForAttack;
    private bool _isAttack = false;

    private void Start() => _currentTimeForAttack = _maxTimeForAttack;

    private void Update() => FindPlayer();

    private void FindPlayer()
    {
        if (_searcher.Player == null)
        {
            _currentTimeForAttack = _maxTimeForAttack;
            _isAttack = false;

            return;
        }
        else
        {
            Vector2 distanceToPlayer = transform.position - _searcher.Player.transform.position;

            Debug.Log(distanceToPlayer.x);

            if (_searcher.Player.TryGetComponent(out Health health))
            {
                if (distanceToPlayer.x < _rangeForAttack && distanceToPlayer.x > -_rangeForAttack)
                {
                    TryAttack();

                    if (_isAttack)
                        health.TakeDamage(_damage);
                }
            }
        }
    }

    private void TryAttack()
    {
        if (_currentTimeForAttack >= 0)
        {
            _currentTimeForAttack -= Time.deltaTime;
            _isAttack = false;
        }
        else
        {
            _currentTimeForAttack = _maxTimeForAttack;
            _isAttack = true;
        }
    }
}