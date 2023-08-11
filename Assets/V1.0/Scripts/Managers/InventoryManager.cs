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

    public Item AddItemToInventory(Item item)
    {
        if (inventory.Items.Count >= inventoryCapacity) return item;
        inventory.Items.Add(item);
        if (!inventory.itemsCount.ContainsKey(item.itemName))
        {
            List<Item> newItemsList = new List<Item>();
            newItemsList.Add(item);
            inventory.itemsCount.Add(item.itemName, newItemsList);
        }
        else inventory.itemsCount[item.itemName].Add(item);
        ShowItemCount(inventory.itemsCount);
        return item;
    }

    public void ShowItemCount(Dictionary<string, List<Item>> items)
    {
        foreach (var item in items)
        {
            Debug.Log(item.Key + "count is: " + item.Value.Count);
        }
    }
}
