using UnityEngine;
using Mapbox.Unity.Map;

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
