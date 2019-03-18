using UnityEngine;
using Mapbox.Unity.Map;

/// <summary>
/// The Mapbox satellite map is a bit difficult to toggle, so this script
/// exposes controls for changing the visibility of the map model.
/// </summary>
public class HideMapboxMap : MonoBehaviour
{
    [SerializeField]
    private bool hideOnStart = false;

    private Behaviour mapboxComponent;

    void Start() {
        mapboxComponent = GetComponent<AbstractMap>();
        if (hideOnStart)
        {
            this.OnNextTick(() => SetActive(false));
        }
    }

    public void SetActive(bool active) {
        mapboxComponent.enabled = active;
        foreach (var renderer in GetComponentsInChildren<MeshRenderer>()) {
            renderer.enabled = active;
        }
    }
}
