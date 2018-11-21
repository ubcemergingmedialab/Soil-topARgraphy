using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class QuizQuestionsListUi : MonoBehaviour {
    public GameObject MCQuestionPrefab;
    public GameObject ShortAnswerQuestionPrefab;  

    [SerializeField]
	private UiContent defaultContent = null;

	[ContextMenu("Refresh")]
	void Start() {
		if (defaultContent != null) {
			Display(defaultContent.quizzes);
		}
	}
 
    public void Display(List<QuizContent> loQuizcontent) {
        // Destroy all children 
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        // Make new children
        foreach (var content in loQuizcontent) {
            GameObject prefab;
            if (content is MultipleChoice) {
                prefab = MCQuestionPrefab;
            } else if (content is ShortAnswer) {
                prefab = ShortAnswerQuestionPrefab;
            } else {
                continue;
            }
            var quizGameObject = Instantiate(prefab, transform); 
            var sharedQuiz = quizGameObject.GetComponent<SharedQuizUi>();
            sharedQuiz.Display(content);
		}
    }
}