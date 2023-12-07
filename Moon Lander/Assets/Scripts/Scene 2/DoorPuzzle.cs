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
            // Deactivate doors immediately
            SetDoorsActive(false);

            // Activate task1 after door1 is set active
            Invoke("ActivateTask1", 2f);

            // Invoke a method to reactivate doors after 10 seconds
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
        // Reactivate doors after the specified delay
        SetDoorsActive(true);
    }
}
