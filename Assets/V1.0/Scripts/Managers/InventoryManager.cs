using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public int inventoryCapacity;
    public List<Item> items = new List<Item>();
    public Dictionary<string, List<Item>> itemsCount = new Dictionary<string, List<Item>>();


    #region Singleton
    public void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    public Item AddItemToInventory(Item item)
    {
        if (items.Count < inventoryCapacity)
        {
            items.Add(item);
            if (!itemsCount.ContainsKey(item.itemName)) 
            {
                List<Item> newItemsList = new List<Item>();
                newItemsList.Add(item);
                itemsCount.Add(item.itemName , newItemsList);
            } 
            else itemsCount[item.itemName].Add(item);     
            ShowItemCount(itemsCount);
        }
        else
        {
            Debug.Log("Inventory is full!");
            return null;
        }
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
