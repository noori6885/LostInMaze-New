using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [Header("UI")]
    public GameObject pressEUI;

    private bool playerNear = false;

    private void Start()
    {
        if (pressEUI != null)
        {
            pressEUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerNear)
        {
            Debug.Log("Player Near Key");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E Pressed - Key Collected");

                PlayerInventory.hasKey = true;

                if (pressEUI != null)
                    pressEUI.SetActive(false);

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter : " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Entered Trigger");

            playerNear = true;

            if (pressEUI != null)
                pressEUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit : " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Left Trigger");

            playerNear = false;

            if (pressEUI != null)
                pressEUI.SetActive(false);
        }
    }
}