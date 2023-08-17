using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Crafted Item")]
public class CraftedItem : Item
{
    public CraftedItemType ItemType;
    public List<ConsumableEffect> Effects;
    public GameObject ItemPrefab;
}
[System.Serializable]
public class ConsumableEffect
{
    public ConsumableEffectType EffectType;
    public float Value;
}