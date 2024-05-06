using UnityEngine;

public class Grounded : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField, Range(0f, 10f)] private float _rayDistance;
    [SerializeField] private LayerMask _layer;

    private bool _isGrounded;

    public bool TryFindGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_player.position, Vector2.down, _rayDistance, _layer);

        if (hit.collider != null)
            _isGrounded = true;
        else
            _isGrounded = false;

        return _isGrounded;
    }
}