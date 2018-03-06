using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sets up the panel control buttons (close, previous, next) by binding them
/// to a PanelPager in the nearest parent
/// </summary>
public class SetupPanelControls : MonoBehaviour
{
    /// <summary>Button to close the panels</summary>
    public Button closeButton = null;
    /// <summary>Button to move to the previous panel</summary>
    public Button previousButton = null;
    /// <summary>Button to move to the next panel</summary>
    public Button nextButton = null;

    void Start()
    {
        try
        {
            Setup();
        }
        catch (MissingComponentException e)
        {
            Debug.LogError(e);
        }
    }

    /// <summary>
    /// Setup buttons. Will reset their On Click listeners.
    /// </summary>
    [ContextMenu("Setup Controls")]
    public void Setup()
    {
        var parentPager = GetComponentInParent<PanelPager>();
        if (parentPager == null)
            throw new MissingComponentException("Missing a parent with PanelPager component");

        if (closeButton)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(() => parentPager.gameObject.SetActive(false));
        }
        if (previousButton)
        {
            previousButton.onClick.RemoveAllListeners();
            previousButton.onClick.AddListener(parentPager.PreviousPanel);
        }
        if (nextButton)
        {
            nextButton.onClick.RemoveAllListeners();
            nextButton.onClick.AddListener(parentPager.NextPanel);
        }
    }
}