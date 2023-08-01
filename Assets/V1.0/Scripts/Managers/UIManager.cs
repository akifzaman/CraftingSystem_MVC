using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Transform ItemUIContainer;
    public GameObject ItemUI;
    #region Singleton
    public void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    public void OnItemPicked(Item item)
    {
        CreateItemUI(item);
    }

    public void CreateItemUI(Item item)
    {
        var go = Instantiate(ItemUI, ItemUIContainer);
        go.GetComponent<Image>().sprite = item.itemIcon;
    }
}
