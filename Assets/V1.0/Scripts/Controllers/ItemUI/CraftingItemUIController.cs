public class CraftingItemUIController : InventoryItemUIController
{
    public void InitializeCraftingItem(CraftingItem item)
    {
        craftingItem = item;
        DropButton.onClick.AddListener(OnDropBackToInventoryButtonClicked);
    }
    public void OnDropBackToInventoryButtonClicked()
    {
        DropBackToInventory(craftingItem);
    }
    public void DropBackToInventory(CraftingItem item)
    {
        InventoryManager.Instance.inventory.Items.Add(item);
        var go = UIManager.Instance.OnItemPicked(item);
        CraftingManager.instance.Items.Remove(item);
        Destroy(gameObject);
    }
}
