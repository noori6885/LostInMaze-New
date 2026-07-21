using UnityEngine;

public class DoorWin : MonoBehaviour
{
    public GameObject gameWinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && KeyCollect.hasKey)
        {
            gameWinText.SetActive(true);

            Debug.Log("GAME WIN");
            Time.timeScale = 0f;
        }
    }
}