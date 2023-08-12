using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
	public static CraftingManager instance;

	public int CraftingItemSlotCount;
	public List<string> CraftingRecipes = new List<string>();
	public List<Item> Items = new List<Item>();
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
		CraftButton.onClick.AddListener(Craft);
    }
	public void Craft()
	{
		if (!IsRecipeValid())
		{
			UIManager.Instance.ShowAlert("Invalid Recipe!");
			return;
		}
		UIManager.Instance.OnItemCrafted();
		Items.Clear();
    }
	public bool IsRecipeValid()
	{
		if (Items.Count < CraftingItemSlotCount) return false;
		else
		{
			currentCraftingRecipe = "";
			foreach (Item item in Items) currentCraftingRecipe += item.itemName;
			foreach (var recipe in CraftingRecipes)
			{
				if (recipe == currentCraftingRecipe) return true;
			}
		}
        return false;
    }
}
