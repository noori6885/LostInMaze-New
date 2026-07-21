using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject MainMenu;
    public GameObject SettingsPanel;
    public GameObject CreditsPanel;

    private void Start()
    {
        // Safety check
        if (MainMenu != null)
            MainMenu.SetActive(true);

        if (SettingsPanel != null)
            SettingsPanel.SetActive(false);

        if (CreditsPanel != null)
            CreditsPanel.SetActive(false);
    }

    // Start Game
    public void StartGame()
    {
        SceneManager.LoadScene("LostInMaze");
    }

    // Open Settings
    public void OpenSettings()
    {
        if (MainMenu != null)
            MainMenu.SetActive(false);

        if (SettingsPanel != null)
            SettingsPanel.SetActive(true);
    }

    // Close Settings
    public void CloseSettings()
    {
        if (SettingsPanel != null)
            SettingsPanel.SetActive(false);

        if (MainMenu != null)
            MainMenu.SetActive(true);
    }

    // Open Credits
    public void OpenCredits()
    {
        if (MainMenu != null)
            MainMenu.SetActive(false);

        if (CreditsPanel != null)
            CreditsPanel.SetActive(true);
    }

    // Close Credits
    public void CloseCredits()
    {
        if (CreditsPanel != null)
            CreditsPanel.SetActive(false);

        if (MainMenu != null)
            MainMenu.SetActive(true);
    }

    // Exit Game
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}