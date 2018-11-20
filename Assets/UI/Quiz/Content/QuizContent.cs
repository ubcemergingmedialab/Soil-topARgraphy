using UnityEngine;

public abstract class QuizContent : ScriptableObject {

	/// <summary>Title of the info panel.</summary>
	public string Question; 

	public string ResultText; 

	public string FailedText = "Incorrect, try again";
}
