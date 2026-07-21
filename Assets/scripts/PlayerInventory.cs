using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static bool hasKey = false;

    public GameObject keyIcon;

    private void Start()
    {
        hasKey = false;

        if (keyIcon != null)
            keyIcon.SetActive(false);
    }

    private void Update()
    {
        if (hasKey && keyIcon != null)
        {
            keyIcon.SetActive(true);
        }
    }
}