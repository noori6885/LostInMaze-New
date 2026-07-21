using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float stoppingDistance = 1.5f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator not found on Zombie!");
        }
    }

    private void Update()
    {
        if (player == null || animator == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime);

            transform.LookAt(player);

            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}