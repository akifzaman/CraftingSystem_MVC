using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public int inventoryCapacity;
    public Inventory inventory = new Inventory();

    #region Singleton
    public void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    public CraftingItem AddItemToInventory(CraftingItem item)
    {
        if (inventory.Items.Count >= inventoryCapacity) return item;
        inventory.Items.Add(item);
        if (!inventory.inventoryItemsCount.ContainsKey(item.itemName))
        {
            List<CraftingItem> newItemsList = new List<CraftingItem>();
            newItemsList.Add(item);
            inventory.inventoryItemsCount.Add(item.itemName, newItemsList);
        }
        else inventory.inventoryItemsCount[item.itemName].Add(item);
        return item;
    }
}
