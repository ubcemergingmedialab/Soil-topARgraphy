using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public LayerMask flagLayers;

    void TappedFlag(Vector3 position)
    {
        var ray = Camera.main.ScreenPointToRay(position);

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, flagLayers))
        {
            var flagPanel = hit.collider.GetComponent<FlagPanel>();
            if (!flagPanel)
            {
                Debug.LogWarning("Missing FlagPanel " + hit.collider.gameObject);
            }
            else if (!flagPanel.panel)
            {
                Debug.LogWarning(hit.collider.gameObject + " FlagPanel has no panel object set");
            }
            else flagPanel.panel.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TappedFlag(Input.mousePosition);
        }
        else if (Input.touchCount > 0)
        {
            TappedFlag(Input.touches[0].position);
        }
    }
}
