using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _moveSpeed;
    [SerializeField, Range(0f, 10f)] private float _jumpSpeed;
    [SerializeField] private InputProcessing _input;

    private SpriteRenderer _playerSprite;
    private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _playerSprite = GetComponent<SpriteRenderer>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Jump();
        Rotate();
        Move();
    }

    private void Move() => transform.position += new Vector3(_input.Direction * _moveSpeed * Time.deltaTime, 0);

    private void Rotate() => _playerSprite.flipX = _input.IsRotate;

    private void Jump()
    {
        if (_input.CanJump)
            _playerRigidbody.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);
    }
}