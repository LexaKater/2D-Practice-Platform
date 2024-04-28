using UnityEngine;

public class TrigerZone : MonoBehaviour
{
    public PlayerMovement Player { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player))
            Player = player;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player))
            Player = null;
    }
}
