using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Consumable Item")]
public class ConsumableItem : Item
{
    public ItemType itemType = ItemType.Consumable;
    public List<ConsumableEffect> effects;
}
[System.Serializable]
public class ConsumableEffect
{
    public ConsumableEffectType effectType;
    public float value;
}