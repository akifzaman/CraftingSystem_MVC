using UnityEngine;
using UnityEngine.UI;

public class CraftedItemUIController : InventoryItemUIController
{
    public CraftedItem craftedItem;
    public Button EquipButton;
    public void Initialize(CraftedItem item)
    {
        craftedItem = item;
        EquipButton.onClick.AddListener(OnEquipButtonClicked);
    }

    public void OnEquipButtonClicked()
    {
        Debug.Log(craftedItem.ItemName + " is equipped");
        Equip(craftedItem);
    }
    public void Equip(CraftedItem item)
    {
        InventoryManager.Instance.inventory.CraftedItems.Remove(item);
        UIManager.Instance.OnItemEquipped(item);
        Destroy(gameObject);
    }
}
