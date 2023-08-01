using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/Item")]
public class Item : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
    public int healAmount;
    public int damageAmount;
}
