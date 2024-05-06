using UnityEngine;

public class SearchEnemy : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _layer;

    private Vector2 _direction = Vector2.right;
    private bool _isFind = false;
    private Health _enemy;

    private void Update() => SetDirection();

    public bool TryFindEnemy()
    {
        RaycastHit2D enemy = Physics2D.Raycast(transform.position, _direction, _rayDistance, _layer);

        if (enemy.collider != null)
        {
            if (enemy.collider.TryGetComponent(out Health health))
            {
                _isFind = true;
                _enemy = health;

                return _isFind;
            }
        }
        else
        {
            _enemy = null;
        }

        _isFind = false;

        return _isFind;
    }

    public Health GetEnemy() => _enemy;

    private void SetDirection()
    {
        if (Input.GetKeyDown(KeyCode.A))
            _direction = Vector2.left;

        if (Input.GetKeyDown(KeyCode.D))
            _direction = Vector2.right;
    }
}