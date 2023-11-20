using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public static bool Inventory = false;

    public GameObject InventoryUI;
   
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
      InventoryUI.SetActive(false);
      Inventory = false;
    }

    void Pause ()
    {
        InventoryUI.SetActive(true);
        Inventory = true;
    }
}
