using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public int damage = 20;
    public float attackCooldown = 1.5f;

    private float nextAttackTime = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (Time.time >= nextAttackTime)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);

                Debug.Log("Zombie Hit Player");
            }

            nextAttackTime = Time.time + attackCooldown;
        }
    }
}