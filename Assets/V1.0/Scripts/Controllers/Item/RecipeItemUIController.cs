using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeItemUIController : MonoBehaviour
{
    public Button resultItem;
    public CraftedItem resultItemCrafted;
    public List<Button> recipeItem;
    public List<CraftingItem> recipeItemCrafting;
    private void Start()
    {
        resultItem.image.sprite = resultItemCrafted.itemIcon;
        for (int i = 0; i < recipeItem.Count; i++)
        {
            recipeItem[i].image.sprite = recipeItemCrafting[i].itemIcon;
        }
    }
}
