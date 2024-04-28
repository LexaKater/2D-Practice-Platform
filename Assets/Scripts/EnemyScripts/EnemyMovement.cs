using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private TrigerZone _trigerZone;
    [SerializeField, Range(0f, 10f)] private float _speed;
    [SerializeField, Range(-10f, 10f)] private float _rangeForStop;

    private int _currentWaypoint = 0;
    private Vector2 _target;

    private void Update() => Move();

    private void Move()
    {
        if (_trigerZone.Player == null)
        {
            if (transform.position == _waypoints[_currentWaypoint].position)
                _currentWaypoint = ++_currentWaypoint % _waypoints.Length;

            _target = _waypoints[_currentWaypoint].position;
        }
        else
        {
            _target = _trigerZone.Player.transform.position;

            Vector2 distanceToPlayer = transform.position - _trigerZone.Player.transform.position;

            if (distanceToPlayer.x < _rangeForStop)
                return;
        }

        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }
}