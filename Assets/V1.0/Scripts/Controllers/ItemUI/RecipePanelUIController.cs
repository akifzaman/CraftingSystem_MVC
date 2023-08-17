using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanelUIController : MonoBehaviour
{
    public List<Button> RecipeItem;
    public List<Item> RecipeItemCrafting;
    private void Awake()
    {
        for (int i = 0; i < RecipeItem.Count; i++)
        {
            int index = i;
            RecipeItem[i].image.sprite = RecipeItemCrafting[i].ItemIcon;
            RecipeItem[i].onClick.AddListener(() => OnRecipeCraftingItemClicked(RecipeItemCrafting[index]));
        }
    }
    public void OnRecipeCraftingItemClicked(Item item)
    {
        UIManager.Instance.ShowItemDetails(item);
    }
}
