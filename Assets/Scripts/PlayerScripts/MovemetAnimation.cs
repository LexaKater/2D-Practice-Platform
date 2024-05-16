using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovemetAnimation : MonoBehaviour
{
    [SerializeField] private InputProcessing _input;
    [SerializeField] private PlayerMovement _movement;

    public readonly int Speed = Animator.StringToHash(nameof(Speed));
    public readonly int IsJump = Animator.StringToHash(nameof(IsJump));

    private Animator _playerAnimator;  

    private void Start() => _playerAnimator = GetComponent<Animator>();

    private void Update()
    {
        PlayMoveAnimation();
        PlayJumpAnimation();
    }

    private void PlayMoveAnimation()
    {
        float idleSpeed = 0;
        float moveSpeed = 1;

        if (_input.Direction != idleSpeed)
            _playerAnimator.SetFloat(Speed, moveSpeed);
        else
            _playerAnimator.SetFloat(Speed, idleSpeed);
    }

    private void PlayJumpAnimation()
    {
        if (_input.CanJump)
            _playerAnimator.SetBool(IsJump, _input.CanJump);

        _playerAnimator.SetBool(IsJump, _input.CanJump);
    }
}