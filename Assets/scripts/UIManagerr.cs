using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerr : MonoBehaviour
{
    public void RestartGame()
    {
        // Resume game
        Time.timeScale = 1f;

        // Reload current scene (LostInMaze)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        // Resume game before changing scene
        Time.timeScale = 1f;

        // Go back to Main Menu
        SceneManager.LoadScene("MainMenu");
    }
}