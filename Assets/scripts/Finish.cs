using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject winText;
    public EnemyChase enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winText.SetActive(true);

            enemy.gameEnded = true;

            Time.timeScale = 0f;
        }
    }
}