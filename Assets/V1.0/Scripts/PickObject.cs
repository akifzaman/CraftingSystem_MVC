using UnityEngine;

public class PickObject : MonoBehaviour, IPickable
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
        //Add this item to the player's inventory if there is empty space
        Item addedItem = InventoryManager.instance.AddItemToInventory(item);
        if (addedItem != null) Destroy(gameObject);
    }

}
