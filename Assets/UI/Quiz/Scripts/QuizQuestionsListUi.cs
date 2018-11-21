using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class QuizQuestionsListUi : MonoBehaviour {
    public GameObject MCQuestionPrefab;
    public GameObject ShortAnswerQuestionPrefab;  
 
    public void Display(List<QuizContent> loQuizcontent) {
        // Destroy all children 
        foreach (Transform child in transform) {
            Object.Destroy(child);
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
            Object.Instantiate(prefab, transform); 
		}
    }
}