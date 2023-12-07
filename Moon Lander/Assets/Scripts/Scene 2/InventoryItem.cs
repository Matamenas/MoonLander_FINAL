using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public GameObject replacementObject;    // The object to be activated after destruction
    public GameObject task1;                // The object to be enabled after the keycard is removed

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Player" (you can customize this tag)
        if (other.CompareTag("Player"))
        {
            ReplaceObject();
        }
    }

    private void ReplaceObject()
    {
        // Disable the original object
        gameObject.SetActive(false);

        // Enable the replacement object
        if (replacementObject != null)
        {
            replacementObject.SetActive(true);
            EnableTask1(); // Enable the task1 object after replacing the keycard
        }
        else
        {
            Debug.LogWarning("Replacement object is not assigned.");
        }
    }

    private void EnableTask1()
    {
        // Enable the task1 object
        if (task1 != null)
        {
            task1.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Task1 object is not assigned.");
        }
    }
}
