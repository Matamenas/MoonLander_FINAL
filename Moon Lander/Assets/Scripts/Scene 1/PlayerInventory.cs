using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int numberOfCrystals { get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondCollected;

    public void CrystalCollected()
    {
        numberOfCrystals++;
        OnDiamondCollected.Invoke(this);
    }
}