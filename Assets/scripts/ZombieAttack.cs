using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public int damage = 10;
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;

    private float nextAttackTime;

    private Transform player;
    private PlayerHealth playerHealth;
    private ZombieAI zombieAI;

    void Start()
    {
        zombieAI = GetComponent<ZombieAI>();

        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p != null)
        {
            player = p.transform;
            playerHealth = p.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (player == null || playerHealth == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange && Time.time >= nextAttackTime)
        {
            playerHealth.TakeDamage(damage);

            Debug.Log("Zombie Hit Player");

            nextAttackTime = Time.time + attackCooldown;

            if (zombieAI != null)
                zombieAI.ResetAttack();
        }
    }
}