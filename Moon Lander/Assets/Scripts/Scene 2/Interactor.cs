using UnityEngine;

public class TriggerExample : MonoBehaviour
{
    public string targetTag = "Player";
    public GameObject interactorPanel;
    public GameObject generatorPanel;
    public GameObject keyPickupObject; // The GameObject to check if it's enabled
    public GameObject mainDoorTrigger; // The new GameObject to enable after 'E' key is pressed

    private bool isPlayerInsideTrigger = false;
    private bool hasToggled = false;
    private bool isInteractionEnabled = true;

    private void CheckKeyPickup()
    {
        // Check if the assigned GameObject is active
        if (keyPickupObject != null && keyPickupObject.activeSelf)
        {
            // If the GameObject is active, allow the code to run
            isInteractionEnabled = true;
        }
        else
        {
            // If the GameObject is not active, disable interaction
            isInteractionEnabled = false;
            if (interactorPanel != null)
            {
                interactorPanel.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isPlayerInsideTrigger = true;
            hasToggled = false;

            // Check KeyPickupObject status before activating the interactor panel
            CheckKeyPickup();

            if (isPlayerInsideTrigger && isInteractionEnabled && interactorPanel != null)
            {
                interactorPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isPlayerInsideTrigger = false;
            hasToggled = false;

            // Deactivate the interactor panel regardless of isInteractionEnabled
            if (interactorPanel != null)
            {
                interactorPanel.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (isPlayerInsideTrigger && !hasToggled && Input.GetKeyDown(KeyCode.E) && isInteractionEnabled)
        {
            if (interactorPanel != null)
            {
                interactorPanel.SetActive(!interactorPanel.activeSelf);
            }

            if (generatorPanel != null)
            {
                generatorPanel.SetActive(!generatorPanel.activeSelf);
            }

            // Disable the keyPickupObject panel
            if (keyPickupObject != null)
            {
                keyPickupObject.SetActive(false);
            }

            // Enable the mainDoorTrigger GameObject
            if (mainDoorTrigger != null)
            {
                mainDoorTrigger.SetActive(true);
            }

            hasToggled = true;
            isInteractionEnabled = false; // Disable interaction after 'E' key is pressed
        }
    }
}
