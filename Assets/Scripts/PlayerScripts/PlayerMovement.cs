using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _moveSpeed;
    [SerializeField, Range(0f, 10f)] private float _jumpSpeed;

    private Animator _playerAnimator;
    private SpriteRenderer _playerSprite;
    private Rigidbody2D _playerRigidbody;
    private bool _isJump;
    private bool _isDoubleJump;
    private bool _isGrounded;
    private float _rayDistance = 0.9f;
    private string _runParameter = "speed";
    private string _jumpParameter = "isJump";

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
            _playerAnimator.SetFloat(_runParameter, _moveSpeed);
        else
            _playerAnimator.SetFloat(_runParameter, idleSpeed);
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
        RaycastHit2D hit = Physics2D.Raycast(_playerRigidbody.position, Vector2.down, _rayDistance, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            _isGrounded = true;
            _isDoubleJump = false;
            _isJump = false;

            _playerAnimator.SetBool(_jumpParameter, _isJump);
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
                _playerAnimator.SetBool(_jumpParameter, _isJump);
            }
            else if (!_isDoubleJump && _playerRigidbody.velocity.y < 0)
            {
                _playerRigidbody.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);

                _isDoubleJump = true;
                _playerAnimator.SetBool(_jumpParameter, _isDoubleJump);
            }
        }
    }
}