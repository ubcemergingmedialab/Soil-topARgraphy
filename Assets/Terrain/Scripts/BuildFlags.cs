using System.Collections.Generic;
using UnityEngine;

public class BuildFlags : MonoBehaviour
{
    public FlagPanel FlagPrefab;
    public FlagPanel BonusPrefab;
    public List<UiContent> Flags = new List<UiContent>();

    void Start() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        Build();
    }

    public void Build() {
        foreach (var content in Flags) {
            var prefab = content.IsBonus ? BonusPrefab : FlagPrefab;
            var panel = (FlagPanel) Instantiate(prefab, transform);
            panel.transform.localPosition = content.MapPosition;
            panel.Content = content;
        }
    }
}
