using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public GameObject replacementObject;    
    public GameObject task1;                

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            ReplaceObject();
        }
    }

    private void ReplaceObject()
    {
       
        gameObject.SetActive(false);

        
        if (replacementObject != null)
        {
            replacementObject.SetActive(true);
            EnableTask1(); 
        }
        else
        {
            Debug.LogWarning("Replacement object is not assigned.");
        }
    }

    private void EnableTask1()
    {
        
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
