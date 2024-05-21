using System.Collections.Generic;
using UnityEngine;

public class SearchEnemy : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private VampirismZone _vampireZone;

    private List<Transform> _enemies = new List<Transform>();
    private Vector2 _direction = Vector2.right;

    public bool IsFind { get; private set; } = false;
    public Health Enemy { get; private set; }
    public Health ClosestEnemy { get; private set; }

    private void Update() => SetDirection();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health enemyHealth))
        {
            IsFind = true;
            _enemies.Add(enemyHealth.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health enemyHealth))
        {
            IsFind = false;
            _enemies.Remove(enemyHealth.transform);
        }
    }

    public bool TryFindEnemy()
    {
        RaycastHit2D enemy = Physics2D.Raycast(transform.position, _direction, _rayDistance, _layer);

        bool isFind = false;

        if (enemy.collider != null)
        {
            if (enemy.collider.TryGetComponent(out Health health))
            {
                isFind = true;
                Enemy = health;
            }
        }
        else
        {
            isFind = false;
        }

        return isFind;
    }

    public void FindClosestEnemy()
    {
        if (_enemies.Count == 0)
            return;

        ClosestEnemy = null;

        float closestDistance = float.MaxValue;
        Vector3 currentPosition = transform.position;

        foreach (Transform enemy in _enemies)
        {
            Vector3 differencebetweenTarget = enemy.position - currentPosition;
            float distanceToTarget = differencebetweenTarget.sqrMagnitude;

            if (distanceToTarget < closestDistance)
            {
                closestDistance = distanceToTarget;

                if (enemy.TryGetComponent(out Health health))
                    ClosestEnemy = health;
            }
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