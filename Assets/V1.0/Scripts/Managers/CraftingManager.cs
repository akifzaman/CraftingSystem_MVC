using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public static CraftingManager instance;
    public int CraftingItemSlotCount;
    public List<string> CraftingRecipes = new List<string>();
    public List<CraftingItem> Items = new List<CraftingItem>();
    public List<CraftedItem> ResultItems = new List<CraftedItem>();
    public string currentCraftingRecipe;
    public Button CraftButton;
    [SerializeField] private int ResultItemIndex;
    public Item currentCraftingItem;
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

    #region Item Drag Functions
    public void OnMouseDownCraftingItem(Item item)
    {
        if (currentCraftingItem == null)
        {
            currentCraftingItem = item;
            UIManager.Instance.CustomCursor.gameObject.SetActive(true);
            UIManager.Instance.CustomCursor.sprite = item.ItemIcon;
        }
    }
    public void OnMouseUpCraftingItem()
    {
        if (currentCraftingItem != null)
        {
            currentCraftingItem = null;
            UIManager.Instance.CustomCursor.gameObject.SetActive(false);
        }
    }
    #endregion

    public void OnCraftButtonClicked()
    {
        CraftedItem craftedItem = Craft();
        if (craftedItem == null) return;
        InventoryManager.Instance.inventory.CraftedItems.Add(craftedItem);
        UIManager.Instance.OnItemCrafted(craftedItem);
    }
    public CraftedItem Craft()
    {
        if (!IsRecipeValid())
        {
            UIManager.Instance.ShowAlert("Invalid Recipe!");
            return null;
        }
        UIManager.Instance.DestroyCraftingItems();
        UIManager.Instance.ShowAlert(ResultItems[ResultItemIndex].ItemName + " Crafted!");
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
            foreach (CraftingItem item in Items) currentCraftingRecipe += item.ItemName;
            foreach (var recipe in CraftingRecipes)
            {
                ResultItemIndex++;
                if (recipe == currentCraftingRecipe) return true;
            }
        }
        return false;
    }
}







//Second approach for crafting
//Without ordering/string match crafting, following this you can craft placing the items in any order
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.UI;

//[Serializable]
//public class CraftingRecipe
//{
//    public List<string> ingredients = new List<string>(4);
//}

//public class CraftingManager : MonoBehaviour
//{
//    public static CraftingManager instance;

//    public int CraftingItemSlotCount;
//    public int ResultItemIndex;
//    public List<CraftingRecipe> CraftingRecipes = new List<CraftingRecipe>();
//    public List<CraftingItem> Items = new List<CraftingItem>();
//    public List<CraftedItem> ResultItems = new List<CraftedItem>();
//    public string currentCraftingRecipe;
//    public Button CraftButton;

//    #region Singleton
//    public void Awake()
//    {
//        if (instance == null) instance = this;
//        else Destroy(this.gameObject);
//    }
//    #endregion
//    public void Start()
//    {
//        CraftButton.onClick.AddListener(OnCraftButtonClicked);
//    }
//    public void OnCraftButtonClicked()
//    {
//        CraftedItem craftedItem = Craft();
//        if (craftedItem == null) return;
//        InventoryManager.instance.inventory.CraftedItems.Add(craftedItem);
//        UIManager.Instance.OnItemCrafted(craftedItem);
//    }

//    public CraftedItem Craft()
//    {
//        if (!IsRecipeValid())
//        {
//            UIManager.Instance.ShowAlert("Invalid Recipe!");
//            return null;
//        }
//        UIManager.Instance.DestroyCraftingItems();
//        UIManager.Instance.ShowAlert(ResultItems[ResultItemIndex].itemName + " Crafted!");
//        Items.Clear();
//        return ResultItems[ResultItemIndex];
//    }

//    public bool IsRecipeValid()
//    {
//        if (Items.Count < CraftingItemSlotCount) return false;
//        else
//        {
//            List<string> ingredientNames = new List<string>();
//            foreach (CraftingItem item in Items)
//            {
//                ingredientNames.Add(item.itemName);
//            }
//            ingredientNames.Sort();

//            foreach (var recipe in CraftingRecipes)
//            {
//                List<string> sortedRecipe = new List<string>(recipe.ingredients);
//                sortedRecipe.Sort();

//                if (IsListsEqual(ingredientNames, sortedRecipe))
//                {
//                    ResultItemIndex = CraftingRecipes.IndexOf(recipe);
//                    return true;
//                }
//            }
//        }

//        return false;
//    }

//    private bool IsListsEqual(List<string> list1, List<string> list2)
//    {
//        if (list1.Count != list2.Count)
//        {
//            return false;
//        }

//        for (int i = 0; i < list1.Count; i++)
//        {
//            if (list1[i] != list2[i])
//            {
//                return false;
//            }
//        }

//        return true;
//    }
//}
