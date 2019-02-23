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
    /// <summary>Button to complete onboarding and exit to the next scene</summary>
    public Button DoneButton = null;

    /// <summary>Index of the currently active panel</summary>
    private int currentIndex = 0;

    void Start()
    {
        // Attches respective button variables to unity buttons
        
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
    /// Disables or enables buttons, depending on current page.
    /// </summary>
    private void SetButtonsInteractable()
    {
        // Sets the previous button active on every panel except the first
        if (PreviousButton) {
            PreviousButton.gameObject.SetActive(currentIndex > 0);
        }
        // Sets the next button active on every panel except the last
        if (NextButton) {
            NextButton.gameObject.SetActive(currentIndex < Panels.Count - 1);
        }
        // Only sets the done button active on the last panel
        if (DoneButton) {
            DoneButton.gameObject.SetActive(currentIndex == Panels.Count - 1);
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

    public void Reset()
    {
        ChangeActivePanel(0);
    }
}
