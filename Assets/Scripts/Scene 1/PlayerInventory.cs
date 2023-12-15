using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int numberOfCrystals { get; set;}
    public UnityEvent<PlayerInventory> OnCrystalCollected;


    public void CrystalCollected()
    {
        numberOfCrystals++;
        OnCrystalCollected.Invoke(this);
    }

}