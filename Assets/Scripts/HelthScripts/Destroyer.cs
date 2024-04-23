using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable() => _health.OwnerDied += KillOwner;

    private void OnDisable() => _health.OwnerDied -= KillOwner;

    private void KillOwner() => Destroy(gameObject);
}
