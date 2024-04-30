using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _moveSpeed;
    [SerializeField, Range(0f, 10f)] private float _jumpSpeed;
    [SerializeField, Range(0f, 10f)] private float _rayDistance;
    [SerializeField] private LayerMask _layer;

    public readonly int SpeedParameter = Animator.StringToHash(nameof(Speed));
    public readonly int IsJumpParameter = Animator.StringToHash(nameof(IsJump));

    private const string Speed = nameof(Speed);
    private const string IsJump = nameof(IsJump);

    private Animator _playerAnimator;
    private SpriteRenderer _playerSprite;
    private Rigidbody2D _playerRigidbody;
    private bool _isJump;
    private bool _isDoubleJump;
    private bool _isGrounded;


    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerSprite = GetComponent<SpriteRenderer>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();
        Move();
        Jump();
    }

    private void Move()
    {
        float idleSpeed = 0;

        float direction = Input.GetAxis("Horizontal");
        transform.position += new Vector3(direction * _moveSpeed * Time.deltaTime, 0);

        if (direction != idleSpeed)
            _playerAnimator.SetFloat(SpeedParameter, _moveSpeed);
        else
            _playerAnimator.SetFloat(SpeedParameter, idleSpeed);
    }

    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.A))
            _playerSprite.flipX = true;

        if (Input.GetKeyDown(KeyCode.D))
            _playerSprite.flipX = false;
    }

    private void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(_playerRigidbody.position, Vector2.down, _rayDistance, _layer);

        if (hit.collider != null)
        {
            _isGrounded = true;
            _isDoubleJump = false;
            _isJump = false;

            _playerAnimator.SetBool(IsJumpParameter, _isJump);
        }
        else
        {
            _isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGrounded)
            {
                _playerRigidbody.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);

                _isJump = true;
                _playerAnimator.SetBool(IsJumpParameter, _isJump);
            }
            else if (!_isDoubleJump && _playerRigidbody.velocity.y < 0)
            {
                _playerRigidbody.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);

                _isDoubleJump = true;
                _playerAnimator.SetBool(IsJumpParameter, _isDoubleJump);
            }
        }
    }
}