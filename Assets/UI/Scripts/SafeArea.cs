using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Deals with screen notches by expanding the padding of a layout group to be
/// at least the size of a notch.
/// </summary>
public class SafeArea : MonoBehaviour
{
    public RectOffset Padding;
    public Vector2 NotchSpacing;

    [SerializeField]
    private LayoutGroup layoutGroup;

    private Rect lastSafeArea = new Rect();

    void Start() { Refresh(); }
    void Update() { Refresh(); }

    public void Refresh() {
        if (Screen.safeArea != lastSafeArea) {
            lastSafeArea = Screen.safeArea;

            // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
            Vector2 anchorMin = lastSafeArea.position;
            Vector2 anchorMax = lastSafeArea.position + lastSafeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            layoutGroup.padding.left = XPad(lastSafeArea.xMin, Padding.left);
            layoutGroup.padding.right = XPad(lastSafeArea.xMax, Padding.right);
            layoutGroup.padding.top = YPad(lastSafeArea.yMin, Padding.top);
            layoutGroup.padding.bottom = YPad(lastSafeArea.yMax, Padding.bottom);
        }
    }

    private int XPad(float safeArea, int padding) {
        return Mathf.Max(Mathf.RoundToInt((safeArea / Screen.width) + NotchSpacing.x), padding);
    }
    private int YPad(float safeArea, int padding) {
        return Mathf.Max(Mathf.RoundToInt((safeArea / Screen.height) + NotchSpacing.y), padding);
    }
}
