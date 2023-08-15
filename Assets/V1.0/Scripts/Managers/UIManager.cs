using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI healthAmountText;
    public TextMeshProUGUI damageAmountText;
    public TextMeshProUGUI AlertText;
    public Transform InventoryItemUIContainer;
    public Transform CraftingItemUIContainer;
    public Transform CraftedItemUIContainer;
    public GameObject InventoryItemPrefab;
    public GameObject CraftingItemPrefab;
    public GameObject CraftedItemPrefab;
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
    public void OnItemPicked(CraftingItem item)
    {
        var go = CreateInventoryItemUI(item, InventoryItemPrefab, InventoryItemUIContainer);
        go.GetComponent<InventoryItemUIController>().Initialize(item);
    }
    public void OnItemUsed(CraftingItem item)
    {
        var go = CreateInventoryItemUI(item, CraftingItemPrefab, CraftingItemUIContainer);
        go.GetComponent<CraftingItemUIController>().Initialize(item);
    }
    public GameObject CreateInventoryItemUI(CraftingItem item, GameObject itemPrefab, Transform container)
    {
        var go = Instantiate(itemPrefab, container);
        go.GetComponent<Image>().sprite = item.itemIcon;
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
        go.GetComponent<Image>().sprite = item.itemIcon;
        return go;
    }
    public void ChangePlayerStat(CraftedItem item)
    {
        if (item.itemType == CraftedItemType.Equippable)
        {
            //
        }
        else if (item.itemType == CraftedItemType.Consumable)
        {
            for (int i = 0; i < item.effects.Count; i++)
            {
                if (item.effects[i].effectType == ConsumableEffectType.HealthIncrease) player.health += item.effects[i].value;
                if (item.effects[i].effectType == ConsumableEffectType.DamageBoost) player.damage += item.effects[i].value;
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

    //Player stat UI
    public void UpdatePlayerHUD(Player player)
    {
        healthAmountText.text = $"Health: {player.health}";
        damageAmountText.text = $"Damage: {player.damage}";
    }
}
