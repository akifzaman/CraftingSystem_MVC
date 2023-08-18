using UnityEngine;

public class PickItem : MonoBehaviour, IPickable
{
    [SerializeField]
    private CraftingItem item;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.ItemIcon;
    }
    public void Pick()
    {
        CraftingItem addedItem = InventoryManager.Instance.AddItemToInventory(item);
        if (addedItem != null) Destroy(gameObject);    
    }

}
