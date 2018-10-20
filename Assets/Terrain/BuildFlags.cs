using System.Collections.Generic;
using UnityEngine;

public class BuildFlags : MonoBehaviour
{
    public FlagPanel FlagPrefab;
    public List<UiContent> Flags = new List<UiContent>();

    void Start() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        Build();
    }

    public void Build() {
        foreach (var content in Flags) {
            var panel = (FlagPanel) Instantiate(FlagPrefab, transform);
            panel.transform.position = content.MapPosition;
            panel.Content = content;
        }
    }
}
