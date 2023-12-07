using UnityEngine;

public class TriggerExample : MonoBehaviour
{
    public string targetTag = "Player";
    public GameObject interactorPanel;
    public GameObject generatorPanel;
    public GameObject keyPickupObject; 
    public GameObject mainDoorTrigger; 
    public GameObject task1; 
    public GameObject nextTasks; 
    public GameObject remGenerator; 

    private bool isPlayerInsideTrigger = false;
    private bool hasToggled = false;
    private bool isInteractionEnabled = true;

    private void CheckKeyPickup()
    {
        
        if (keyPickupObject != null && keyPickupObject.activeSelf)
        {
            
            isInteractionEnabled = true;
        }
        else
        {
            
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

                
                if (generatorPanel.activeSelf && task1 != null)
                {
                    task1.SetActive(true);

                   
                    Invoke("ActivateNextTasksAndDeactivateRemGenerator", 2f);
                }
            }

            
            if (keyPickupObject != null)
            {
                keyPickupObject.SetActive(false);
            }

           
            if (mainDoorTrigger != null)
            {
                mainDoorTrigger.SetActive(true);
            }

            hasToggled = true;
            isInteractionEnabled = false;
        }
    }

    private void ActivateNextTasksAndDeactivateRemGenerator()
    {
        
        if (nextTasks != null)
        {
            nextTasks.SetActive(true);
        }

       
        if (remGenerator != null)
        {
            remGenerator.SetActive(false);
        }
    }
}
