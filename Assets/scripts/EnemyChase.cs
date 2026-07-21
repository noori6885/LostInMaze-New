using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 4f;
    public GameObject gameOverText;
    public bool gameEnded = false;

    void Update()
{
    if (player != null && !gameEnded)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            chaseSpeed * Time.deltaTime
        );
    }
}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
       gameOverText.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}