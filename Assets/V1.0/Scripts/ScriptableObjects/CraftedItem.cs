using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Crafted Item")]
public class CraftedItem : Item
{
    public CraftedItemType itemType;
    public List<ConsumableEffect> effects;
    public GameObject itemPrefab;
}
[System.Serializable]
public class ConsumableEffect
{
    public ConsumableEffectType effectType;
    public float value;
}