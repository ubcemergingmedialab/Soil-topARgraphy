using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handler for the Satellite/Heightmap toggle.
/// Expected to be attached to same object as Toggle.
/// </summary>
public class TerrainToggle : MonoBehaviour
{
    /// <summary>Label indicating currently displayed terrain</summary>
    public Text label;

    /// <summary>Heightmap terrain object</summary>
    public GameObject heightmap;
    /// <summary>Text for `label` when heightmap mesh is onscreen</summary>
    public string heightmapText = "HEIGHTMAP";

    /// <summary>Satellite terrain object</summary>
    public GameObject satellite;
    /// <summary>Text for `label` when satellite mesh is onscreen</summary>
    public string satelliteText = "SATELLITE";

    /// <summary>Callback for when the toggle is flipped.</summary>
    /// <param name="change">changed toggle. if on, show satellite.</param>
    public void ToggleChanged(Toggle change)
    {
        heightmap.SetActive(!change.isOn);
        satellite.SetActive(change.isOn);

        label.text = change.isOn ? satelliteText : heightmapText;
    }
}
