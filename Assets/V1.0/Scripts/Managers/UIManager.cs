using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI healthAmountText;
    public TextMeshProUGUI damageAmountText;
    public Transform ItemUIContainer;
    public GameObject ItemUI;
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
        CreateItemUI(item);
    }

    public void CreateItemUI(Item item)
    {
        var go = Instantiate(ItemUI, ItemUIContainer);
        go.GetComponent<Image>().sprite = item.itemIcon;
        go.GetComponent<ItemController>().Initialize(item);
    }
}
