using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiQuizPanel : MonoBehaviour {
	/// <summary>Game object used to display title.</summary>
	public Text QuizQuestion;
    /// <summary>Prefab used to display one image.</summary>
	public GameObject ButtonPrefab;

	private List<GameObject> buttonObjects = new List<GameObject>();

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
		QuizQuestion.text = content.QuizQuestion.ToUpper();

		CacheInstances(ButtonPrefab, content.Images.Count, buttonObjects);
		for (int i = 0; i < content.QuizAnswers.Count; i++) {
			var btn = buttonObjects[i].GetComponentInChildren<Button>();
			var btnText = buttonObjects[i].GetComponentInChildren<Text>();

			btnText.text = content.QuizAnswers[i].Answer;
		}
	}

	private void CacheInstances<T>(T prefab, int amountWanted, List<T> cache) where T : Object {
		if (amountWanted > cache.Count) {
			while (cache.Count < amountWanted) {
				T instance = (T) Instantiate(prefab, transform);
				cache.Add(instance);
			}
		} else if (amountWanted < cache.Count) {
			while (cache.Count > amountWanted) {
				int last = cache.Count - 1;
				T instance = cache[last];
				cache.RemoveAt(last);
				Destroy(instance);
			}
		}
	}
}
