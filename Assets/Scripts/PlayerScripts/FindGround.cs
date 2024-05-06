using UnityEngine;

public class FindGround : MonoBehaviour
{
    [SerializeField] Rigidbody2D _player;
    [SerializeField, Range(0f, 10f)] private float _rayDistance;
    [SerializeField] private LayerMask _layer;

    public bool IsGrounded { get; private set; }

    private void Update() => LaunchRaycast();

    private void LaunchRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(_player.position, Vector2.down, _rayDistance, _layer);

        if (hit.collider != null)
            IsGrounded = true;
        else
            IsGrounded = false;
    }
}
