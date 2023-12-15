using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                audioSource.Play();
                myDoor.Play("door_2_open" , 0 , 0.0f);
            }

            else if (closeTrigger)
            {
                myDoor.Play("door_2_close" , 0 , 0.0f);
                
            }
        }
    }


}