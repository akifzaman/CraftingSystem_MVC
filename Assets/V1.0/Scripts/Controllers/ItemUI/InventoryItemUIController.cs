using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUIController : MonoBehaviour
{
    public CraftingItem craftingItem;
    public Button UseButton;
    public Button DropButton;
    public Vector3 ItemPosition;
    public void Initialize(CraftingItem item)
    {
        craftingItem = item;
        UseButton.onClick.AddListener(OnUseButtonClicked);
        DropButton.onClick.AddListener(OnDropButtonClicked);
    }

    public void OnDropButtonClicked()
    {
        Drop(craftingItem);
    }
    public void Drop(CraftingItem item)
    {
        InstantiateItemOnWorldSpace(item);
        InventoryManager.Instance.inventory.Items.Remove(item);
        Destroy(gameObject);
    }
    public void InstantiateItemOnWorldSpace(CraftingItem item)
    {
        ItemPosition = GameObject.Find("Player").transform.position;
        ItemPosition.x += 1;
        var go = Instantiate(item.ItemPrefab, ItemPosition, Quaternion.identity);
    }

    public void OnUseButtonClicked()
    {
        Use(craftingItem);
    }
	public void Use(CraftingItem item)
	{
        if (CraftingManager.instance.Items.Count >= CraftingManager.instance.CraftingItemSlotCount) return;
        CraftingManager.instance.Items.Add(item);
        UIManager.Instance.OnItemUsed(item);
        InventoryManager.Instance.inventory.Items.Remove(item);
		Destroy(gameObject);
	}
}
