using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public Button soundButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private bool isMuted = false;

    void Start()
    {
        musicSource.Play();
        UpdateButtonIcon();
    }

    public void ToggleSound()
    {
        isMuted = !isMuted;

        musicSource.mute = isMuted;

        UpdateButtonIcon();
    }

    void UpdateButtonIcon()
    {
        Image img = soundButton.GetComponent<Image>();

        if (img == null) return;

        img.sprite = isMuted ? soundOffSprite : soundOnSprite;
    }
}