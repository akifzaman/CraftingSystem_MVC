using UnityEngine;

public class PickItem : MonoBehaviour, IPickable
{
    [SerializeField]
    private CraftingItem item;
    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.ItemIcon;
    }
    public void Pick()
    {
        CraftingItem addedItem = InventoryManager.Instance.AddItemToInventory(item);
        if (addedItem != null)
        { 
            UIManager.Instance.OnItemPicked(addedItem);
            Destroy(gameObject);
        }
    }

}
