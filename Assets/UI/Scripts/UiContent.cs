using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds information for a single UI panel and its corresponding flag.
/// </summary>
[CreateAssetMenu]
public class UiContent : ScriptableObject {
	/// <summary>Position of the flag on the map, in Unity world units.</summary>
	public Vector3 MapPosition;

	/// <summary>Title of the info panel.</summary>
	public string Title;
	/// <summary>Text shown in the panel.
	/// Each string is one paragraph. Shown below title.</summary>
	[TextArea(3, 10)]
	public List<string> Description = new List<string>();
	/// <summary>Images show in the panel, below description text.</summary>
	public List<Sprite> Images = new List<Sprite>();

}
