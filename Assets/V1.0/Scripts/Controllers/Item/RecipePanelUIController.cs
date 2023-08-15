using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanelUIController : MonoBehaviour
{
    public List<Button> recipeItem;
    public List<Item> recipeItemCrafting;
    private void Awake()
    {
        for (int i = 0; i < recipeItem.Count; i++)
        {
            int index = i;
            recipeItem[i].image.sprite = recipeItemCrafting[i].itemIcon;
            recipeItem[i].onClick.AddListener(() => OnRecipeCraftingItemClicked(recipeItemCrafting[index]));
        }
    }
    public void OnRecipeCraftingItemClicked(Item item)
    {
        UIManager.Instance.ShowItemDetails(item);
    }
}
