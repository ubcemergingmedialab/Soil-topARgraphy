using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Lets the user page through panels set as children of this object.
/// </summary>
public class PanelPager : MonoBehaviour
{
    /// <summary>Name of the tag used to identify panels</summary>
    [SerializeField]
    private string panelTag = "Panel";
    /// <summary>List of panels</summary>
    public List<GameObject> Panels = new List<GameObject>();

    /// <summary>Button to close the panels</summary>
    public Button CloseButton = null;
    /// <summary>Button to move to the previous panel</summary>
    public Button PreviousButton = null;
    /// <summary>Button to move to the next panel</summary>
    public Button NextButton = null;

    /// <summary>Index of the currently active panel</summary>
    private int currentIndex = 0;

    void Start()
    {
        // Auto-fill panels list
        if (Panels.Count == 0)
        {
            SetupPanelsList();
        }

        SetButtonsInteractable();
    }

    /// <summary>Auto-fill the panels list.</summary>
    [ContextMenu("Setup Panels")]
    private void SetupPanelsList() {
        foreach (Transform child in GetComponentInChildren<Transform>(true)) {
            if (child.gameObject.tag == panelTag) {
                var i = Panels.Count;
                child.gameObject.SetActive(i == currentIndex);
                Panels.Add(child.gameObject);
            }
        }
    }

    /// <summary>
    /// Setup buttons. Will reset their On Click listeners.
    /// </summary>
    [ContextMenu("Setup Controls")]
    private void SetupButtonListeners() {
        if (CloseButton)
        {
            CloseButton.onClick.RemoveAllListeners();
            CloseButton.onClick.AddListener(() => gameObject.SetActive(false));
        }
        if (PreviousButton)
        {
            PreviousButton.onClick.RemoveAllListeners();
            PreviousButton.onClick.AddListener(PreviousPanel);
        }
        if (NextButton)
        {
            NextButton.onClick.RemoveAllListeners();
            NextButton.onClick.AddListener(NextPanel);
        }
    }

    /// <summary>
    /// Disables or enables buttons, depending on current page.
    /// </summary>
    private void SetButtonsInteractable()
    {
        if (PreviousButton) {
            PreviousButton.interactable = currentIndex > 0;
        }
        if (NextButton) {
            NextButton.interactable = currentIndex < Panels.Count - 1;
        }
    }

    private void ChangeActivePanel(int index)
    {
        index = Mathf.Clamp(index, 0, Panels.Count - 1);

        Panels[currentIndex].SetActive(false);
        Panels[index].SetActive(true);
        currentIndex = index;

        SetButtonsInteractable();
    }

    /// <summary>
    /// Use this as the On Click listener for a UI button, to move to the
    /// previous panel.
    /// </summary>
    public void PreviousPanel()
    {
        ChangeActivePanel(currentIndex - 1);
    }

    /// <summary>
    /// Use this as the On Click listener for a UI button, to move to the
    /// next panel.
    /// </summary>
    public void NextPanel()
    {
        ChangeActivePanel(currentIndex + 1);
    }
}
