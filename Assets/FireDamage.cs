using UnityEngine;

public class FireDamage : MonoBehaviour
{
    [SerializeField] private int damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}