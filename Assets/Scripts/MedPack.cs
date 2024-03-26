using UnityEngine;

public class MedPack : MonoBehaviour
{
    [SerializeField] private float _healValue = 5f;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Health health))
        {
            health.RestoreHealth(_healValue);
            Destroy(gameObject);
        }
    }
}
