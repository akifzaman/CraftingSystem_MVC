using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUIController : MonoBehaviour
{
    public CraftingItem item;
    public Button UseButton;
    public Button DropButton;
    public Vector3 ItemPosition;
    public void Initialize(CraftingItem item)
    {
        this.item = item;
        UseButton.onClick.AddListener(OnUseButtonClicked);
        DropButton.onClick.AddListener(OnDropButtonClicked);
    }

    public void OnDropButtonClicked()
    {
        Drop(item);
    }
    public void Drop(CraftingItem item)
    {
        InstantiateItemOnWorldSpace(item);
        InventoryManager.instance.inventory.Items.Remove(item);
        Destroy(gameObject);
    }
    public void InstantiateItemOnWorldSpace(CraftingItem item)
    {
        ItemPosition = GameObject.Find("Player").transform.position;
        ItemPosition.x += 1;
        var go = Instantiate(item.itemPrefab, ItemPosition, Quaternion.identity);
    }

    public void OnUseButtonClicked()
    {
        Use(item);
    }
	public void Use(CraftingItem item)
	{
        if (CraftingManager.instance.Items.Count >= CraftingManager.instance.CraftingItemSlotCount) return;
        CraftingManager.instance.Items.Add(item);
        UIManager.Instance.OnItemUsed(item);
        InventoryManager.instance.inventory.Items.Remove(item);
		Destroy(gameObject);
	}
}
