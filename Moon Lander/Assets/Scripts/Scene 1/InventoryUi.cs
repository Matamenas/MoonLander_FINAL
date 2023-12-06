
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI crystalText;

    // Start is called before the first frame update
    void Start()
    {
       crystalText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCrystalText(PlayerInventory playerInventory)
    {
        crystalText.text = playerInventory.numberOfCrystals.ToString();
    }
}
