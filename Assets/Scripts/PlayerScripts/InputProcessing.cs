using UnityEngine;

public class InputProcessing : MonoBehaviour
{
    [SerializeField] private FindGround _ground;

    public bool CanJump { get; private set; } = false;
    public bool CanRotate { get; private set; } = false;
    public float Direction { get; private set; }

    private void Update()
    {
        SetRotate();
        SetDirection();
        TryJump();
    }

    private void SetDirection() => Direction = Input.GetAxis("Horizontal");

    private void SetRotate()
    {
        if (Input.GetKeyDown(KeyCode.A))
            CanRotate = true;

        if (Input.GetKeyDown(KeyCode.D))
            CanRotate = false;
    }

    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_ground.IsGrounded)
                CanJump = true;
            else
                CanJump = false;
        }
        else
        {
            CanJump = false;
        }
    }
}
