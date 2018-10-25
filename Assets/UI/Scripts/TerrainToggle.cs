using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class TerrainToggleEvent : UnityEvent<MapType>
{}

/// <summary>
/// Handler for the Satellite/Heightmap toggle.
/// Expected to be attached to same object as Toggle.
/// </summary>
public class TerrainToggle : MonoBehaviour, CurrentMapTypeProvider
{
    /// <summary>Label indicating currently displayed terrain</summary>
    public Text label;

    public TerrainToggleEvent OnChange;

    private Toggle toggle;

    public MapType CurrentMapType
    {
        get { return toggle.isOn ? MapType.Satellite : MapType.Heightmap; }
    }

    void Awake() {
        toggle = GetComponent<Toggle>();
        UpdateLabel();
    }

    /// <summary>Callback for when the toggle is flipped.</summary>
    /// <param name="change">changed toggle. if on, show satellite.</param>
    public void ToggleChanged()
    {
        OnChange.Invoke(CurrentMapType);
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        label.text = CurrentMapType.ToFriendlyString().ToUpper();
    }
}
