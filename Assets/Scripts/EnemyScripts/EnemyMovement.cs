using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField, Range(0f, 10f)] private float _speed;

    private int _currentWaypoint = 0;

    private void Update() => Move();

    private void Move()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}
