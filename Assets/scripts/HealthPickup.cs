using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [Header("Health Settings")]
    public int healAmount = 25;

    [Header("Pickup Sound")]
    public AudioClip pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);

                if (pickupSound != null)
                {
                    AudioSource.PlayClipAtPoint(
                        pickupSound,
                        transform.position
                    );
                }

                Destroy(gameObject);
            }
        }
    }
}