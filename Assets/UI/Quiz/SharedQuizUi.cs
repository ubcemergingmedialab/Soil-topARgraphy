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
        ResultObject.gameObject.SetActive(false);

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

        QuizInput.Display(content);
	}

    /// <summary>Handle submitting an answer</summary>
	public void HandleSubmit() {
        if (currentContent == null) return;
        ResultObject.gameObject.SetActive(true);

        var answerIsCorrect = QuizInput.CheckAnswer(currentContent);
        if (answerIsCorrect) {
            ResultObject.text = currentContent.ResultText;
        } else {
            ResultObject.text = currentContent.FailedText;
        }
	}
}