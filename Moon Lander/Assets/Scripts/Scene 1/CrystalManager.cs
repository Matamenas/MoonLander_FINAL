using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.CrystalCollected();
            Destroy(gameObject);
        }
    }
}
