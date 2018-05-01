using UnityEngine;

/// <summary>
/// Used to open panels corresponding to some flag when clicked by the user
/// </summary>
public class Raycaster : MonoBehaviour
{
    /// Layers with flags
    public LayerMask flagLayers;

    /// <summary>Called when the user clicks some point on the screen</summary>
    /// <param name="position">Screen point clicked by user</param>
    void TappedFlag(Vector3 position)
    {
        // Create ray from screen position
        var ray = Camera.main.ScreenPointToRay(position);

        // Cast a ray based on the ray struct. Check if it hits anything
        var hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, flagLayers))
        {
            // Check if the object hit by the raycast has a FlagPanel component.
            // Log a warning if not. If it does, make the referenced panel active.
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
