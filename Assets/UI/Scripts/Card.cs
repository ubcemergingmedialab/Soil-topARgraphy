using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manage a UI card that can be shown and hidden
/// </summary>
public class Card : MonoBehaviour
{
    // The main canvas of the card
    [SerializeField]
    private Canvas canvas;
    // The child canvas where scrollable content is shown (not buttons)
    [SerializeField]
    private Canvas contentCanvas;

    public PanelPager Pager = null;
    public Button.ButtonClickedEvent OnClose;

    void Start() {
        if (Pager) {
            Pager.CloseButton.onClick.AddListener(OnClose.Invoke);
        }
    }

    public void SetVisible(bool visible) {
        canvas.enabled = visible;
        contentCanvas.enabled = visible;
        if (Pager) Pager.Reset();
    }
}
