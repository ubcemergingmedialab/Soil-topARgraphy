using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq; // used for Sum of array

public class PanelPager : MonoBehaviour
{
    public string panelTag = "Panel";
    public List<GameObject> panels = new List<GameObject>();

    int currentIndex = 0;

    void Start()
    {
        // Auto-fill panels list
        if (panels.Count == 0)
        {
            var i = 0;
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == panelTag)
                {
                    panels.Add(child.gameObject);
                    child.gameObject.SetActive(i == currentIndex);
                }
                i++;
            }
        }
    }

    private void ChangeActivePanel(int index)
    {
        index = Mathf.Clamp(index, 0, panels.Count - 1);

        panels[currentIndex].SetActive(false);
        panels[index].SetActive(true);
        currentIndex = index;
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