using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UiContent : ScriptableObject {
	public string Title;
	[TextArea(3, 10)]
	public List<string> Description = new List<string>();
	public List<Sprite> Images = new List<Sprite>();

	public string QuizQuestion;
	public List<string> QuizAnswers = new List<string>();
}
