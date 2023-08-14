using UnityEngine;
using UnityEngine.UI;

public class CraftedItemUIController : MonoBehaviour
{
    public Item item;
    public Button EquipButton;
    public void Initialize(Item item)
    {
        this.item = item;
        EquipButton.onClick.AddListener(OnEquipButtonClicked);
    }

    public void OnEquipButtonClicked()
    {
        Debug.Log(item.itemName + " is equipped");
        Equip(item);
    }
    public void Equip(Item item)
    {
        InventoryManager.instance.inventory.Items.Remove(item);
        UIManager.Instance.OnItemEquipped(item);
        Destroy(gameObject);
    }
}
