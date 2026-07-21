using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public GameObject pressQUI;
    public Animator doorAnimator;

    private bool playerNear = false;

    void Start()
    {
        if (pressQUI != null)
            pressQUI.SetActive(false);
    }

    void Update()
    {
        if (playerNear && PlayerInventory.hasKey && Input.GetKeyDown(KeyCode.Q))
        {
            doorAnimator.SetTrigger("Open");

            if (pressQUI != null)
                pressQUI.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (pressQUI != null)
                pressQUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            if (pressQUI != null)
                pressQUI.SetActive(false);
        }
    }
}