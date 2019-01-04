using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharedQuizUi : MonoBehaviour {
    public Text QuestionObject;
    public Text ResultObject;
    private IQuizInput QuizInput;

    [SerializeField]
    private QuizContent currentContent = null;

    [ContextMenu("Refresh")]
    void Start()
    {
        if (currentContent != null) {
            Display(currentContent);
        }
    }

    /// <summary>Display the given content in the quiz panel</summary>
	public void Display(QuizContent content) {
        currentContent = content;
		QuestionObject.text = content.Question;

        if (QuizInput == null) {
            QuizInput = GetComponent<IQuizInput>();
            if (QuizInput == null)
            {
                throw new NullReferenceException("Missing QuizInput component");
            }
        }

        ResultObject.text = currentContent.ResultText;
        ResultObject.color -= new Color(0, 0, 0, 1);
        QuizInput.Display(content);
	}

    /// <summary>Handle submitting an answer</summary>
	public void HandleSubmit() {
        if (currentContent == null) return;

        var answerIsCorrect = QuizInput.CheckAnswer(currentContent);
        ResultObject.text = answerIsCorrect ? currentContent.ResultText : currentContent.FailedText;
        var color = ResultObject.color;
        color.a = 1;
        ResultObject.color = color;
	}
}
