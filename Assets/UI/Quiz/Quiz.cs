using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Quiz : MonoBehaviour {
	/// <summary>Game object used to display a quiz question.</summary>
	public Text QuestionObject;
	/// <summary>Prefab used to display list of answers.</summary>
    public Button MultipleChoicePrefab;

    public Button SubmitButton; 
    private Text question;

    private Text result; 
	private  List<Button> MultipleChoiceObjects = new List<Button>();

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
        

		/*CacheInstances(AnswerPrefab, content.QuizAnswers.Count, answerObjects);
		for (int i = 0; i < content.QuizAnswers.Count; i++) {
			answerObjects[i].GetComponentInChildren<Text>().text = content.QuizAnswers[i].AnswerText;
		}*/
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

    public void OnClickMultipleChoice(Button option)
    {
        int index = MultipleChoiceObjects.FindIndex(btn => btn == option);
        if (currContent is MultipleChoice) {
            var mc = currContent as MultipleChoice;
            if (mc.QuizOptions[index].IsCorrect) {
                for (int i = 0; i < MultipleChoiceObjects.Count; i++) {
                    MultipleChoiceObjects[i].gameObject.SetActive(false);
                }
            
                result.text = mc.ResultText;
                result.gameObject.SetActive(true);
            }
        }
    }

    public void OnClickTextBox(Button submit)
    {
        int index = MultipleChoiceObjects.FindIndex(btn => btn == submit);
        if (currContent is ShortAnswer) {
            var sa = currContent as ShortAnswer;
            result.text = sa.ResultText;
            result.gameObject.SetActive(true);
        }
    }
    
}
