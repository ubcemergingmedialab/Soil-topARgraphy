using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Lets the user page through panels set as children of this object.
/// </summary>
public class PanelPager : MonoBehaviour
{
    /// <summary>Name of the tag used to identify panels</summary>
    public string panelTag = "Panel";
    /// <summary>List of panels</summary>
    public List<GameObject> panels = new List<GameObject>();

    /// <summary>Button to move to the previous panel</summary>
    public Button previousButton = null;
    /// <summary>Button to move to the next panel</summary>
    public Button nextButton = null;

    /// <summary>Index of the currently active panel</summary>
    int currentIndex = 0;

    void Start()
    {
        // Auto-fill panels list
        if (panels.Count == 0)
        {
            var panelsQuery = from child in transform.GetComponentsInChildren<Transform>(true)
                              let gameObject = child.gameObject
                              where gameObject.tag == panelTag
                              select gameObject;

            panels = panelsQuery.Select((child, i) =>
            {
                child.SetActive(i == currentIndex);
                return child;
            }).ToList();
        }

        SetButtonsInteractable();
    }

    private void SetButtonsInteractable()
    {
        if (previousButton) previousButton.interactable = currentIndex > 0;
        if (nextButton) nextButton.interactable = currentIndex < panels.Count - 1;
    }

    private void ChangeActivePanel(int index)
    {
        index = Mathf.Clamp(index, 0, panels.Count - 1);

        panels[currentIndex].SetActive(false);
        panels[index].SetActive(true);
        currentIndex = index;

        SetButtonsInteractable();
    }

    public void PreviousPanel()
    {
        ChangeActivePanel(currentIndex - 1);
    }

    public void NextPanel()
    {
        ChangeActivePanel(currentIndex + 1);
    }
}