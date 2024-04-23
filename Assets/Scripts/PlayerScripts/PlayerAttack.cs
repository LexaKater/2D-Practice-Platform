using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float _rayDistance;
    [SerializeField] LayerMask _layer;

    private Vector2 _direction;

    private float _damage = 25;
    private float _maxTimeFoattack = 1f;
    private float _currentTimeForAttack = 1f;
    private bool _isAttack = false;

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

                if (_isAttack == false)
                    health.TakeDamage(_damage);
            }
        }
        else
        {
            _currentTimeForAttack = _maxTimeFoattack;
            _isAttack = false;
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
            _currentTimeForAttack = _maxTimeFoattack;
            _isAttack = false;
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
