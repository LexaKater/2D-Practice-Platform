using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Speed = nameof(Speed);
    private const string IsJump = nameof(IsJump);

    [SerializeField, Range(0f, 10f)] private float _moveSpeed;
    [SerializeField, Range(0f, 10f)] private float _jumpSpeed;
    [SerializeField] private InputProcessing _input;

    private Animator _playerAnimator;
    private SpriteRenderer _playerSprite;
    private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerSprite = GetComponent<SpriteRenderer>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Jump();
        Rotate();
        Move();
    }

    private void Move()
    {
        float idleSpeed = 0;

        transform.position += new Vector3(_input.Direction * _moveSpeed * Time.deltaTime, 0);

        if (_input.Direction != idleSpeed)
            _playerAnimator.SetFloat(Speed, _moveSpeed);
        else
            _playerAnimator.SetFloat(Speed, idleSpeed);
    }

    private void Rotate() => _playerSprite.flipX = _input.CanRotate;

    private void Jump()
    {
        if (_input.CanJump)
        {
            _playerRigidbody.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);
            _playerAnimator.SetBool(IsJump, _input.CanJump);
        }

        _playerAnimator.SetBool(IsJump, _input.CanJump);
    }
}