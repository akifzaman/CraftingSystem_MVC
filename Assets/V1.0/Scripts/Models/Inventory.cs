using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<Item> Items = new List<Item>();
    public List<GameObject> ItemPrefabs = new List<GameObject>();
    public Dictionary<string, List<Item>> itemsCount = new Dictionary<string, List<Item>>();
}