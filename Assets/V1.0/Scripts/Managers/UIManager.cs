using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI HealthAmountText;
    public TextMeshProUGUI DamageAmountText;
    public TextMeshProUGUI AlertText;
    public TextMeshProUGUI RecipeItemName;
    public TextMeshProUGUI RecipeItemDescription;
    public Transform InventoryItemUIContainer;
    public Transform CraftingItemUIContainer;
    public Transform CraftedItemUIContainer;
    public GameObject InventoryItemPrefab;
    public GameObject CraftingItemPrefab;
    public GameObject CraftedItemPrefab;
    public GameObject RecipeItemDetailsPanel;
    public Image RecipeItemIcon;
    public InventoryManager inventoryManager;
    public Player player;

    #region Singleton
    public void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    //Alert UI
    public void ShowAlert(string text)
    {
        AlertText.gameObject.SetActive(true);
        AlertText.text = text;
        StartCoroutine(DisableAlertText());
    }
    public IEnumerator DisableAlertText()
    {
        yield return new WaitForSeconds(2.0f);
        AlertText.gameObject.SetActive(false);
    }

    //Inventory items functionalities
    public GameObject OnItemPicked(CraftingItem item)
    {
        var go = CreateInventoryItemUI(item, InventoryItemPrefab, InventoryItemUIContainer);
        go.GetComponent<InventoryItemUIController>().Initialize(item);
        return go;
    }
    public GameObject OnItemUsed(CraftingItem item)
    {
        var go = CreateInventoryItemUI(item, CraftingItemPrefab, CraftingItemUIContainer);
        go.GetComponent<CraftingItemUIController>().Initialize(item);
        return go;
    }
    public GameObject CreateInventoryItemUI(CraftingItem item, GameObject itemPrefab, Transform container)
    {
        var go = Instantiate(itemPrefab, container);
        go.GetComponent<Image>().sprite = item.ItemIcon;
        return go;
    }

    //Crafted items functionalities
    public void OnItemCrafted(CraftedItem item)
    {
        var go = CreateCraftedItemUI(item, CraftedItemPrefab, CraftedItemUIContainer);
        go.GetComponent<CraftedItemUIController>().Initialize(item);
    }
    public void OnItemEquipped(CraftedItem item)
    {    
        ChangePlayerStat(item);  
    }
    public GameObject CreateCraftedItemUI(CraftedItem item, GameObject itemPrefab, Transform container)
    {
        var go = Instantiate(itemPrefab, container);
        go.GetComponent<Image>().sprite = item.ItemIcon;
        return go;
    }
    public void ChangePlayerStat(CraftedItem item)
    {
        if (item.ItemType == CraftedItemType.Equippable)
        {
            //
        }
        else if (item.ItemType == CraftedItemType.Consumable)
        {
            for (int i = 0; i < item.Effects.Count; i++)
            {
                if (item.Effects[i].EffectType == ConsumableEffectType.HealthIncrease) player.health += item.Effects[i].Value;
                if (item.Effects[i].EffectType == ConsumableEffectType.DamageBoost) player.damage += item.Effects[i].Value;
            }
            UpdatePlayerHUD(player);
        }
    }
    public void DestroyCraftingItems()
    {
        foreach (Transform craftingItem in CraftingItemUIContainer)
        {
            Destroy(craftingItem.gameObject);
        }
    }

    //Recipe item functionalities
    public void ShowItemDetails(Item item)
    {
        RecipeItemDetailsPanel.gameObject.SetActive(true);
        RecipeItemIcon.sprite = item.ItemIcon;
        RecipeItemName.text = item.ItemName;
        RecipeItemDescription.text = item.ItemDescription;
    }

    //Player stats UI
    public void UpdatePlayerHUD(Player player)
    {
        HealthAmountText.text = $"Health: {player.health}";
        DamageAmountText.text = $"Damage: {player.damage}";
    }
}
