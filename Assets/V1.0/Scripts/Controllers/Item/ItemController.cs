using UnityEngine;

public class ItemController : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public void Initialize(InventoryManager manager)
    {
        inventoryManager = manager;
    }
    public void OnDropButtonClick(Item item)
    {
        //Destroy(gameObject);
        InventoryManager.instance.inventory.Items.Remove(item);
    }
}
