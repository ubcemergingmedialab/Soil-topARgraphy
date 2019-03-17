using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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
    public UnityEvent OnOpen;
    public UnityEvent OnClose;

    public bool IsOpen {
        get {
            return canvas.enabled;
        }
    }

    void Start() {
        SetVisible(false);
    }

    public void SetVisible(bool visible) {
        canvas.enabled = visible;
        contentCanvas.enabled = visible;
        if (Pager) Pager.Reset();
        (visible ? OnOpen : OnClose).Invoke();
    }
}
