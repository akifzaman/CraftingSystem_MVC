using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
	public static CraftingManager instance;

	public int CraftingItemSlotCount;
	public int ResultItemIndex;
	public List<string> CraftingRecipes = new List<string>();
	public List<Item> Items = new List<Item>();
	public List<Item> ResultItems = new List<Item>();
	public string currentCraftingRecipe;
	public Button CraftButton;

	#region Singleton
	public void Awake()
	{
		if (instance == null) instance = this;
		else Destroy(this.gameObject);
	}
    #endregion

    public void Start()
    {
		CraftButton.onClick.AddListener(OnCraftButtonClicked);
    }
	public void OnCraftButtonClicked()
	{
		Item craftedItem = Craft();
		if (craftedItem == null) return;
		InventoryManager.instance.inventory.Items.Add(craftedItem);
		//UIManager.Instance.OnItemPicked(craftedItem);
		UIManager.Instance.OnItemCrafted(craftedItem);
	}
	public Item Craft()
	{
		if (!IsRecipeValid())
		{
			UIManager.Instance.ShowAlert("Invalid Recipe!");
			return null;
		}
		UIManager.Instance.OnItemCrafted();
        UIManager.Instance.ShowAlert(ResultItems[ResultItemIndex].itemName + " Crafted!");
        Items.Clear();
        return ResultItems[ResultItemIndex];
    }
	public bool IsRecipeValid()
	{
		if (Items.Count < CraftingItemSlotCount) return false;
		else
		{
			currentCraftingRecipe = "";
			ResultItemIndex = -1;
            foreach (Item item in Items) currentCraftingRecipe += item.itemName;
			foreach (var recipe in CraftingRecipes)
			{
				ResultItemIndex++;
				if (recipe == currentCraftingRecipe) return true;
			}
		}
        return false;
    }
}
