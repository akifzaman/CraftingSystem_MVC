using UnityEngine;

public class PickItem : MonoBehaviour, IPickable
{
    [SerializeField]
    private Item item;
    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.itemIcon;
    }
    public void Pick()
    {
        Item addedItem = InventoryManager.instance.AddItemToInventory(item);
        if (addedItem != null)
        { 
            UIManager.Instance.OnItemPicked(addedItem);
            Destroy(gameObject);
        }
    }

}
