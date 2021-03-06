﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPanel : MonoBehaviour {
	/// <summary>Game object used to display title.</summary>
	public Text TitleObject;
	/// <summary>Prefab used to display one paragraph.</summary>
	public Text DescriptionPrefab;
	/// <summary>Prefab used to display one image.</summary>
	public GameObject ImagePrefab;

	private Text title;
	private List<Text> descriptionObjects = new List<Text>();
	private List<GameObject> imageObjects = new List<GameObject>();

	[SerializeField]
	private UiContent defaultContent = null;

	[ContextMenu("Refresh")]
	void Start() {
		if (defaultContent != null) {
			Display(defaultContent);
		}
	}

	/// <summary>Display the given content in the UI</summary>
	public void Display(UiContent content) {
		TitleObject.text = content.Title.ToUpper();

		PrefabList.CacheInstances(DescriptionPrefab, transform, content.Description.Count, descriptionObjects);
		for (int i = 0; i < content.Description.Count; i++) {
			descriptionObjects[i].text = content.Description[i];
		}

		PrefabList.CacheInstances(ImagePrefab, transform, content.Images.Count, imageObjects);
		for (int i = 0; i < content.Images.Count; i++) {
			var img = imageObjects[i].GetComponentInChildren<Image>();
			var fitter = imageObjects[i].GetComponentInChildren<AspectRatioFitter>();
			var sprite = content.Images[i];

			if (sprite) {
				fitter.aspectRatio = sprite.rect.size.x / sprite.rect.size.y;
				img.sprite = sprite;
			}
		}
	}
}
