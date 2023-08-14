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
    public InventoryManager inventoryManager;

    #region Singleton
    public void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    public void UpdatePlayerHUD(Player player)
    {
        healthAmountText.text = $"Health: {player.health}";
        damageAmountText.text = $"Damage: {player.damage}";
    }
    public void OnItemPicked(Item item)
    {
        var go = CreateItemUI(item, InventoryItemPrefab, InventoryItemUIContainer);
        go.GetComponent<ItemController>().Initialize(item);
    }
    public void OnItemCrafted(Item item)
    {
        var go = CreateItemUI(item, InventoryItemPrefab, CraftedItemUIContainer);
        go.GetComponent<ItemController>().Initialize(item);
    }
	public void OnItemUsed(Item item)
	{
		var go = CreateItemUI(item, CraftingItemPrefab, CraftingItemUIContainer);
        go.GetComponent<CraftingItemController>().Initialize(item);
    }
    public void OnItemCrafted()
    {
        foreach (Transform craftingItem in CraftingItemUIContainer)
        {
            Destroy(craftingItem.gameObject);
        }
    }
	public GameObject CreateItemUI(Item item, GameObject itemPrefab, Transform container)
    {
        var go = Instantiate(itemPrefab, container);
        go.GetComponent<Image>().sprite = item.itemIcon;
        return go;
    }
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
}
