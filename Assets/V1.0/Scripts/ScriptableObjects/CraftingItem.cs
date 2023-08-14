using UnityEngine;
[CreateAssetMenu(menuName = "Items/Crafting Item")]
public class CraftingItem : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
    public string itemDescription;
    public GameObject itemPrefab;
}
