using UnityEngine;

/// <summary>
/// Used to open panels corresponding to some flag when clicked by the user
/// </summary>
public class Raycaster : MonoBehaviour
{
    /// Layers with flags
    public LayerMask flagLayers;
	public Transform parent = null;

	private GameObject lastPanel = null;

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
			ProcessFlagPanel (flagPanel, hit.collider.gameObject);
        }
    }

	private void ProcessFlagPanel(FlagPanel flagPanel, GameObject source) {
		if (!flagPanel) {
			Debug.LogWarning ("Missing FlagPanel " + source);
		} else if (flagPanel.path == "") {
			Debug.LogWarning (source + " FlagPanel has no panel path set");
		} else {
			var resource = Resources.Load (flagPanel.path);
			if (resource == null) {
				Debug.LogError (flagPanel.path + " from FlagPanel in " + source + " does not point to a valid resource");
			} else {
				var panel = Instantiate (resource, parent) as GameObject;
				panel.SetActive (true);

				if (lastPanel)
					Object.Destroy (lastPanel);
				lastPanel = panel;
			}
		}
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TappedFlag(Input.mousePosition);
        }
        else if (Input.touchCount == 1)
        {
            TappedFlag(Input.touches[0].position);
        }
    }
}
