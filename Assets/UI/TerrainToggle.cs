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
    /// <summary>Satellite terrain object</summary>
    public GameObject satellite;

    /// <summary>Text for `label` when heightmap mesh is onscreen</summary>
    public string heightmapText = "HEIGHTMAP";
    /// <summary>Text for `label` when satellite mesh is onscreen</summary>
    public string satelliteText = "SATELLITE";

    /// <summary>Callback for when the toggle is flipped.</summary>
    /// <param name="change">changed toggle. if on, show satellite.</param>
    public void ToggleChanged(Toggle change)
    {
        if (heightmap != null) {
            heightmap.SetActive(!change.isOn);
        }
        if (satellite != null) {
            satellite.SetActive(change.isOn);
        }

        label.text = (change.isOn ? satelliteText : heightmapText).ToUpper();
    }
}
