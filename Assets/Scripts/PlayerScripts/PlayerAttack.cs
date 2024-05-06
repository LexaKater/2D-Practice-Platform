using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _maxTimeForAttack;
    [SerializeField] private SearchEnemy _searcher;

    private float _currentTimeForAttack;
    private bool _isAttack = false;

    private void Start() => _currentTimeForAttack = _maxTimeForAttack;

    private void Update() => Attack();

    private void Attack()
    {
        if (_searcher.TryFindEnemy())
        {
            TryAttack();

            if (_isAttack)
                _searcher.GetEnemy().TakeDamage(_damage);
        }
        else
        {
            _currentTimeForAttack = _maxTimeForAttack;
            _isAttack = false;
        }
    }

    private void TryAttack()
    {
        if (_currentTimeForAttack > 0)
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