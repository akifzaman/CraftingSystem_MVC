using UnityEngine;
using UnityEngine.UI;

public class OverlapChecker : MonoBehaviour
{
    public Image ItemImage;
    public RectTransform CraftingPanel;

    private void Update()
    {
        if (ItemImage != null && CraftingPanel != null)
        {
            Rect imageBounds = GetScreenSpaceBounds(ItemImage.rectTransform);
            Rect panelBounds = GetScreenSpaceBounds(CraftingPanel);
            UIManager.Instance.IsOverlapTrue = imageBounds.Overlaps(panelBounds);
        }
    }
    private Rect GetScreenSpaceBounds(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        Vector3 bottomLeft = RectTransformUtility.WorldToScreenPoint(null, corners[0]);
        Vector3 topRight = RectTransformUtility.WorldToScreenPoint(null, corners[2]);
        return new Rect(bottomLeft.x, bottomLeft.y, topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);
    }
}
