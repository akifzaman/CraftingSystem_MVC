using UnityEngine;
using UnityEngine.UI;

public class CraftedItemUIController : MonoBehaviour
{
    public CraftedItem item;
    public Button EquipButton;
    public void Initialize(CraftedItem item)
    {
        this.item = item;
        EquipButton.onClick.AddListener(OnEquipButtonClicked);
    }

    public void OnEquipButtonClicked()
    {
        Debug.Log(item.itemName + " is equipped");
        Equip(item);
    }
    public void Equip(CraftedItem item)
    {
        InventoryManager.instance.inventory.CraftedItems.Remove(item);
        UIManager.Instance.OnItemEquipped(item);
        Destroy(gameObject);
    }
}
