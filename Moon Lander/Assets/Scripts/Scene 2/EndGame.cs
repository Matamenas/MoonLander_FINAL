using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChangeOnKeyPress : MonoBehaviour
{
    public GameObject interactor;
    public GameObject task;
    public GameObject task2;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    private bool isSceneChangeInitiated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Press 'E' to change scene");

            ActivateInteractor();
            ActivateTask();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !isSceneChangeInitiated)
            {
                isSceneChangeInitiated = true;

                DeactivateInteractor();
                ActivateTask2();
                StartCoroutine(CountdownSequence());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DeactivateInteractor();
        }
    }

    private void ActivateInteractor()
    {
        if (interactor != null)
        {
            interactor.SetActive(true);
        }
    }

    private void DeactivateInteractor()
    {
        if (interactor != null)
        {
            interactor.SetActive(false);
        }
    }

    private void ActivateTask()
    {
        if (task != null)
        {
            task.SetActive(true);
        }
    }

    private void ActivateTask2()
    {
        if (task2 != null)
        {
            task2.SetActive(true);
        }
    }

    private IEnumerator CountdownSequence()
    {
        if (obj1 != null) obj1.SetActive(true);

        yield return new WaitForSeconds(1f);

        if (obj1 != null) obj1.SetActive(false);
        if (obj2 != null) obj2.SetActive(true);

        yield return new WaitForSeconds(1f);

        if (obj2 != null) obj2.SetActive(false);
        if (obj3 != null) obj3.SetActive(true);

        yield return new WaitForSeconds(1f);

        if (obj3 != null) obj3.SetActive(false);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("EndGame");
    }
}
