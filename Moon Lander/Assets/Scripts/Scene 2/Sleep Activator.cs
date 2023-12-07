using UnityEngine;

public class SleepActivator : MonoBehaviour
{
    public string playerTag = "Player";
    public GameObject sleepActivatePanel;
    public GameObject door1;
    public GameObject door2;
    public GameObject task1Panel;
    public GameObject sleepRemove; 
    public GameObject generator; 
    public float panelActiveDuration = 5f;

    private bool isPlayerInsideTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerInsideTrigger = true;
            ActivateSleepPanel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerInsideTrigger = false;
        }
    }

    private void ActivateSleepPanel()
    {
        if (sleepActivatePanel != null && isPlayerInsideTrigger)
        {
            sleepActivatePanel.SetActive(true);
            Invoke("DeactivateSleepPanel", panelActiveDuration);
        }
    }

    private void DeactivateSleepPanel()
    {
        if (sleepActivatePanel != null)
        {
            sleepActivatePanel.SetActive(false);
            ActivateDoors();
            ActivateTask1Panel();
            DeactivateSleepRemove(); 
        }
    }

    private void ActivateDoors()
    {
        if (door1 != null)
        {
            door1.SetActive(true);
        }

        if (door2 != null)
        {
            door2.SetActive(true);
        }
    }

    private void ActivateTask1Panel()
    {
        if (task1Panel != null)
        {
            task1Panel.SetActive(true);
        }
    }

    private void DeactivateSleepRemove() 
    {
        if (sleepRemove != null)
        {
            Invoke("DeactivatePanelAfterDelay", 2f);
        }
    }

    private void DeactivatePanelAfterDelay()
    {
        if (sleepRemove != null)
        {
            sleepRemove.SetActive(false);
            ActivateGenerator();
        }
    }

    private void ActivateGenerator()
    {
        if (generator != null)
        {
            generator.SetActive(true);
        }
    }
}
