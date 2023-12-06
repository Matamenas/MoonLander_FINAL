using UnityEngine;

public class ObjectReplacement : MonoBehaviour
{
    public GameObject replacementObject;    // The object to be activated after destruction

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
        }
        else
        {
            Debug.LogWarning("Replacement object is not assigned.");
        }
    }
}
