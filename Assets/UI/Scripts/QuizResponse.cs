using System;

/// <summary>
/// A single answer in a multiple-choice quiz.
/// </summary>
[Serializable]
public class QuizResponse {
    public bool IsCorrect;

	public string Answer;

    /// <summary>Text shown once this answer is selected.</summary>
    public string Hint;
}
