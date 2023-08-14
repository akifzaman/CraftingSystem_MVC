using UnityEngine;

public class PickItem : MonoBehaviour, IPickable
{
    [SerializeField]
    private CraftingItem item;
    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.itemIcon;
    }
    public void Pick()
    {
        CraftingItem addedItem = InventoryManager.instance.AddItemToInventory(item);
        if (addedItem != null)
        { 
            UIManager.Instance.OnItemPicked(addedItem);
            Destroy(gameObject);
        }
    }

}
