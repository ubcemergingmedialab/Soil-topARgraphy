using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SharedQuizUi : MonoBehaviour {
// display question 


/// <summary>Display the given content in the quiz panel</summary>
	public void Display(QuizContent content) {
		QuestionObject.text = content.Question.ToUpper();
	}


// call either MC or Short Answer 

// Display result, either incorrect or resulttext 

}