using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MultipleChoiceUi : MonoBehaviour, IQuizInput {
    public Toggle OptionPrefab;
    public Transform MultipleChoiceOptionContainer;

    private  List<Toggle> multipleChoiceObjects = new List<Toggle>();

    public void Display(QuizContent _content) {
        var content = _content as MultipleChoice;

        PrefabList.CacheInstances(
            prefab: OptionPrefab,
            parent: MultipleChoiceOptionContainer,
            amountWanted: content.QuizOptions.Count,
            cache: multipleChoiceObjects
        );
        for (int i = 0; i < content.QuizOptions.Count; i++) {
			multipleChoiceObjects[i].GetComponentInChildren<Text>().text = content.QuizOptions[i].optionText;
		}
    }

    public bool CheckAnswer(QuizContent _content) {
        var content = _content as MultipleChoice;

        for (int i = 0; i < content.QuizOptions.Count; i++) {
			if (content.QuizOptions[i].IsCorrect != multipleChoiceObjects[i].isOn)
            {
                return false;
            }
		}
        return true;
    }
}
