using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds information for a single UI panel and its corresponding flag.
/// </summary>
[CreateAssetMenu]
public class QuizContent : ScriptableObject {

	/// <summary>Title of the info panel.</summary>
	public string Question; 

	/// <summary>Quiz options for the multiple choice quiz panel.</summary>
	public List<Answer> QuizAnswers = new List<Answer>();

    [Serializable]
    public class Answer {
        public string AnswerText;
        public bool IsCorrect;
    }
}
