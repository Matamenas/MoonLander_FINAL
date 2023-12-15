using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public static bool Inventory = false;

    public GameObject InventoryMenu;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Inventory)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void Resume ()
    {
      InventoryMenu.SetActive(false);
      Inventory = false;
    }

    void Pause ()
    {
        InventoryMenu.SetActive(true);
        Inventory = true;
    }
}
