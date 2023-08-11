using UnityEngine;

[CreateAssetMenu(menuName = "Items/Crafting Item")]
public class CraftingItem : Item
{
    public float craftingTime;
    public ItemType itemType = ItemType.WeaponCrafting;
}
