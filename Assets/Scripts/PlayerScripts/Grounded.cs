using UnityEngine;

public class Grounded : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField, Range(0f, 10f)] private float _rayDistance;
    [SerializeField] private LayerMask _layer;

    public bool TryFindGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_player.position, Vector2.down, _rayDistance, _layer);

        return hit.collider != null;
    }
}