using System.Collections.Generic;

[System.Serializable]
public class Inventory
{
    public List<CraftingItem> Items = new List<CraftingItem>();
    public List<CraftedItem> CraftedItems = new List<CraftedItem>();
    public Dictionary<string, List<CraftingItem>> InventoryItemsCount = new Dictionary<string, List<CraftingItem>>();
    public Dictionary<string, List<CraftedItem>> CraftedItemsCount = new Dictionary<string, List<CraftedItem>>();
}