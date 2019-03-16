using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortAnswerUi : MonoBehaviour, IQuizInput {
    public InputField UserInput;

    public void Display(QuizContent _content) {
        // var content = _content as ShortAnswer;
    }

    public bool CheckAnswer(QuizContent _content) {
        // var content = _content as MultipleChoice;

        return UserInput.text != "";
    }
}
