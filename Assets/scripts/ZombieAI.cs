using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [Header("References")]
    public Transform player;

    [Header("AI Settings")]
    public float chaseDistance = 15f;
    public float attackDistance = 2f;

    private NavMeshAgent agent;
    private Animator animator;
    private AudioSource zombieAudio;

    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        zombieAudio = GetComponent<AudioSource>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

            if (playerObj != null)
                player = playerObj.transform;
            else
                Debug.LogError("Player with tag 'Player' not found!");
        }

        if (agent != null)
            agent.stoppingDistance = attackDistance;
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Player bahar hai
        if (distance > chaseDistance)
        {
            agent.isStopped = true;
            animator.SetBool("IsRunning", false);

            isAttacking = false;

            if (zombieAudio != null && zombieAudio.isPlaying)
                zombieAudio.Stop();

            return;
        }

        // Chase
        if (distance > attackDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);

            animator.SetBool("IsRunning", true);

            isAttacking = false;

            if (zombieAudio != null && !zombieAudio.isPlaying)
                zombieAudio.Play();
        }
        // Attack
        else
        {
            agent.isStopped = true;

            Vector3 dir = player.position - transform.position;
            dir.y = 0f;

            if (dir != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime * 8f);
            }

            animator.SetBool("IsRunning", false);

            if (!isAttacking)
            {
                animator.SetTrigger("Attack");
                isAttacking = true;
            }
        }
    }

    // ZombieAttack script is method ko call karegi
    public void ResetAttack()
    {
        isAttacking = false;
    }
}