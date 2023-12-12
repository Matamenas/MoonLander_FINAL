using UnityEngine;

public class CableInteractor : MonoBehaviour
{
    public GameObject interact;
    public GameObject remCable;
    public GameObject cableFixed;
    public GameObject padActivate;
    public GameObject task1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact.SetActive(false);
        }
    }

    private void Update()
    {
        if (interact.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            ActivateCable();
        }
    }

    private void ActivateCable()
    {
        remCable.SetActive(false);
        cableFixed.SetActive(true);
        padActivate.SetActive(true);
        task1.SetActive(true); 
        interact.SetActive(false); 
    }
}
