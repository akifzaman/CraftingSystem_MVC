using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI healthAmountText;
    public TextMeshProUGUI damageAmountText;
    public Transform InventoryItemUIContainer;
    public Transform CraftingItemUIContainer;
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
        CreateItemUI(item, InventoryItemPrefab, InventoryItemUIContainer);
    }
	public void OnItemUsed(Item item)
	{
		CreateItemUI(item, CraftingItemPrefab, CraftingItemUIContainer);
	}
	public void CreateItemUI(Item item, GameObject itemPrefab, Transform container)
    {
        var go = Instantiate(itemPrefab, container);
        go.GetComponent<Image>().sprite = item.itemIcon;
        go.GetComponent<ItemController>().Initialize(item);
    }
}
