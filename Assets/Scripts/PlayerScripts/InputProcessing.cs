using UnityEngine;

public class InputProcessing : MonoBehaviour
{
    [SerializeField] private Grounded _ground;

    public float Direction { get; private set; }
    public bool IsRotate { get; private set; } = false;
    public bool CanJump { get; private set; } = false;

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
            IsRotate = true;

        if (Input.GetKeyDown(KeyCode.D))
            IsRotate = false;
    }

    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_ground.TryFindGround())
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