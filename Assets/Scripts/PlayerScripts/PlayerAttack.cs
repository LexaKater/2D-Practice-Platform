using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private float _damage;
    [SerializeField] private float _maxTimeForAttack;
    [SerializeField] private LayerMask _layer;

    private Vector2 _direction;
    private float _currentTimeForAttack;
    private bool _isAttack = false;

    private void Start() => _currentTimeForAttack = _maxTimeForAttack;

    private void Update() => FindEnemy();

    private void FindEnemy()
    {
        SetDirection();

        RaycastHit2D enemy = Physics2D.Raycast(transform.position, _direction, _rayDistance, _layer);

        if (enemy.collider != null)
        {
            if (enemy.collider.TryGetComponent(out Health health))
            {
                Attack();

                if (_isAttack)
                    health.TakeDamage(_damage);
            }
        }
        else
        {
            _currentTimeForAttack = _maxTimeForAttack;
            _isAttack = false;
        }
    }

    private void Attack()
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

    private void SetDirection()
    {
        if (Input.GetKeyDown(KeyCode.A))
            _direction = Vector2.left;

        if (Input.GetKeyDown(KeyCode.D))
            _direction = Vector2.right;
    }
}
