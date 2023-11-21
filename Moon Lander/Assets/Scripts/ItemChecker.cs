using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public static bool Inventoryitem = false;

    public GameObject Item;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Keycard"))
        {
            Destroy(other.gameObject);

            if (Inventoryitem)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }

    void Resume ()
    {
      Item.SetActive(false);
      Inventoryitem = false;
    }

    void Pause ()
    {
        Item.SetActive(true);
        Inventoryitem = true;
    }
}
