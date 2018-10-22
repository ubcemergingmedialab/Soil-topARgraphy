using UnityEngine;
using Mapbox.Unity.Map;

public class HideMapboxMap : MonoBehaviour
{
    private Behaviour mapboxComponent;

    void Start() {
        mapboxComponent = GetComponent<AbstractMap>();
    }

    public void SetActive(bool active) {
        mapboxComponent.enabled = active;
        foreach (var renderer in GetComponentsInChildren<MeshRenderer>()) {
            renderer.enabled = active;
        }
    }
}
