public class CraftingItemUIController : InventoryItemUIController
{
    public void Initialize(CraftingItem item)
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
        InventoryManager.instance.inventory.Items.Add(item);
        var go = UIManager.Instance.OnItemPicked(item);
        CraftingManager.instance.Items.Remove(item);
        Destroy(gameObject);
    }
}
