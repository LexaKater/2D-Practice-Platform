using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovemetAnimation : MonoBehaviour
{
    private const string Speed = nameof(Speed);
    private const string IsJump = nameof(IsJump);

    [SerializeField] private InputProcessing _input;
    [SerializeField] private PlayerMovement _playerMovement;

    private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayMoveAnimation();
        PlayJumpAnimation();
    }

    private void PlayMoveAnimation()
    {
        float idleSpeed = 0;

        if (_input.Direction != idleSpeed)
            _playerAnimator.SetFloat(Speed, _playerMovement.GetMoveSpeed());
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
