using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Inventory inventory = new Inventory();
    [SerializeField] private int inventoryCapacity;

    #region Singleton
    public void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    public CraftingItem AddItemToInventory(CraftingItem item)
    {
        if (inventory.Items.Count >= inventoryCapacity) return item;
        inventory.Items.Add(item);
        if (!inventory.InventoryItemsCount.ContainsKey(item.ItemName))
        {
            List<CraftingItem> newItemsList = new List<CraftingItem>();
            newItemsList.Add(item);
            inventory.InventoryItemsCount.Add(item.ItemName, newItemsList);
        }
        else inventory.InventoryItemsCount[item.ItemName].Add(item);
        return item;
    }
}
