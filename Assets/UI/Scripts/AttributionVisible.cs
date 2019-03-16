using UnityEngine;

public class AttributionVisible : MonoBehaviour
{
    /// <summary>Callback for when the toggle is flipped.</summary>
    /// <param name="change">changed toggle. if on, show satellite.</param>
    public void OnMapTypeChange(MapType newType)
    {
        gameObject.SetActive(newType == MapType.Satellite);
    }
}
