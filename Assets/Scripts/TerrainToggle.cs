using UnityEngine;
using UnityEngine.UI;

/// <summary>Handler for the Satellite/Heightmap toggle</summary>
public class TerrainToggle : MonoBehaviour
{
    /// <summary>Label indicating currently displayed terrain</summary>
    public Text label;

    public GameObject heightmap;
    public string heightmapText = "HEIGHTMAP";

    public GameObject satellite;
    public string satelliteText = "SATELLITE";

    public void ToggleChanged(Toggle change)
    {
        heightmap.SetActive(!change.isOn);
        satellite.SetActive(change.isOn);

        label.text = change.isOn ? satelliteText : heightmapText;
    }
}
