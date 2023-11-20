using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public static bool Inventoryitem = false;

    public GameObject ItemUi;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
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
      ItemUi.SetActive(false);
      Inventoryitem = false;
    }

    void Pause ()
    {
        ItemUi.SetActive(true);
        Inventoryitem = true;
    }
}
