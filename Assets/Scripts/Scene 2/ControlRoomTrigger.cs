using UnityEngine;

public class ControlRoomTrigger : MonoBehaviour
{
    public GameObject controlRoomPanel;
    public GameObject tasks3;
    public GameObject remControl;

    private bool controlRoomActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !controlRoomActivated)
        {
            ShowControlRoomPanel();
            controlRoomActivated = true;

            Invoke("EnableTasks3AndDisableRemControl", 2f); // Invoke after 2 seconds
        }
    }

    private void ShowControlRoomPanel()
    {
        if (controlRoomPanel != null)
        {
            controlRoomPanel.SetActive(true);
        }
    }

    private void EnableTasks3AndDisableRemControl()
    {
        if (tasks3 != null)
        {
            tasks3.SetActive(true);
        }

        if (remControl != null)
        {
            remControl.SetActive(false);
        }
    }
}
