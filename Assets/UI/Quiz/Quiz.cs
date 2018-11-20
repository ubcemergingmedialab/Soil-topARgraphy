using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Quiz : MonoBehaviour {
	/// <summary>Game object used to display a quiz question.</summary>
	public Text QuestionObject;
	/// <summary>Prefab used to display list of answers.</summary>
    public Toggle OptionPrefab;

    public Transform MultipleChoiceOptionContainer;

    public Button SubmitButton; 
    private Text question;

    private Text result; 
	private  List<Toggle> MultipleChoiceObjects = new List<Toggle>();

	[SerializeField]
	private QuizContent defaultContent = null;
    private QuizContent currContent = null; 

	[ContextMenu("Refresh")]
	void Start() {
		if (defaultContent != null) {
			Display(defaultContent);
		}
	}

	/// <summary>Display the given content in the quiz panel</summary>
	public void Display(QuizContent content) {
		QuestionObject.text = content.Question.ToUpper();
        currContent = content;

        // Populate MultipleChoiceObjects
        

		PrefabList.CacheInstances(
            OptionPrefab, 
            MultipleChoiceOptionContainer, 
            (content as MultipleChoice).QuizOptions.Count, 
            MultipleChoiceObjects
        );
		for (int i = 0; i < content.QuizAnswers.Count; i++) {
			answerObjects[i].GetComponentInChildren<Text>().text = content.QuizAnswers[i].AnswerText;
		}
	}

    public void OnClickSubmitButton()
    { 
        if (SubmitButton) {
            if (currContent is MultipleChoice) {
                var mc = currContent as MultipleChoice;
                bool allCorrect = true;

                for (int i = 0; i < MultipleChoiceObjects.Count; i++) {
                    if (mc.QuizOptions[i].IsCorrect != MultipleChoiceObjects[i].isOn)
                    {
                        allCorrect = false;
                        break; 
                    }
                }
            
                result.gameObject.SetActive(true);
                if (allCorrect) {
                    result.text = mc.ResultText;
                } else {
                    result.text = "Incorrect Answer, try again!";
                }
            } 
            else if (currContent is ShortAnswer) {
                var sa = currContent as ShortAnswer;
                result.text = sa.ResultText;
                result.gameObject.SetActive(true);
            }
        } 
    }
}
