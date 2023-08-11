using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
	public static CraftingManager instance;

	public int CraftingItemSlotCount;
	public List<string> CraftingRecipes = new List<string>();
	public List<Item> Items = new List<Item>();

	#region Singleton
	public void Awake()
	{
		if (instance == null) instance = this;
		else Destroy(this.gameObject);
	}
	#endregion
}
