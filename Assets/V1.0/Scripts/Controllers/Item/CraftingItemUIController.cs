using UnityEngine;
using UnityEngine.UI;

public class CraftingItemUIController : MonoBehaviour
{
    public Item item;
    public Button DropButton;
    public void Initialize(Item item)
    {
        this.item = item;
        DropButton.onClick.AddListener(OnDropButtonClicked);
    }

    public void OnDropButtonClicked()
    {
        DropBackToInventory(item);
    }
    public void DropBackToInventory(Item item)
    {
        InventoryManager.instance.inventory.Items.Add(item);
        UIManager.Instance.OnItemPicked(item);
        CraftingManager.instance.Items.Remove(item);
        Destroy(gameObject);
    }
}
