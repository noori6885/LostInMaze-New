using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    public static bool hasKey = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something touched Key");

        if (other.CompareTag("Player"))
        {
            hasKey = true;
            gameObject.SetActive(false);

            Debug.Log("Key Collected");
        }
    }
}