using UnityEngine;
using UnityEngine.UI;

public class TerrainToggle : MonoBehaviour
{
    public GameObject Heightmap;
    public GameObject Map;

    public void ToggleChanged(Toggle change)
    {
        Heightmap.SetActive(!change.isOn);
        Map.SetActive(change.isOn);
    }
}
