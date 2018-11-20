using UnityEngine;

public abstract class QuizContent : ScriptableObject {

	/// <summary>Title of the info panel.</summary>
	public string Question; 

	/// <summary>Quiz options for the multiple choice quiz panel.</summary>
	public string ResultText; 
}
