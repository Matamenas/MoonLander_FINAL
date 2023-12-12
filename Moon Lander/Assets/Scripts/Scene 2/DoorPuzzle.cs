using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject task1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            SetDoorsActive(false);

            
            Invoke("ReactivateDoors", 10f);
        }
    }

    private void SetDoorsActive(bool isActive)
    {
        if (door1 != null)
            door1.SetActive(isActive);

        if (door2 != null)
            door2.SetActive(isActive);
    }

    private void ActivateTask1()
    {
        if (task1 != null)
        {
            task1.SetActive(true);
        }
    }

    private void ReactivateDoors()
    {
        
        SetDoorsActive(true);
    }
}
