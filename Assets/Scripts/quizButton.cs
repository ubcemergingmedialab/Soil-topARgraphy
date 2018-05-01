using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuizButton : MonoBehaviour
{
    /// <summary>Default title, used when quiz is reset.</summary>
    public string title = "Hey, want to take a quiz?";

    /// <summary>Reference to response textbox</summary>
    public Text Textbox;

    /// <summary>
    /// List of possible responses when an answer is clicked.
    /// The index of each string corresponds to the index of the button.
    /// </summary>
    public List<string> Responses = new List<string>() {
        "Yeees",
        "Aww why not?",
        "please?",
        "CORRECT! A+ for you"
    };

    /// <summary>
    /// List of buttons that can be clicked.
    /// When an answer is selected, all other buttons will be hidden.
    /// </summary>
    public List<Button> AnswerButtons = new List<Button>();
    public int ChoiceMade = -1;

    /// <summary>
    /// Click listener assigned to the answer buttons. Should be called
    /// with the index of the button.
    /// </summary>
    public void ChooseOption(int num)
    {
        Textbox.text = num < Responses.Count ? Responses[num] : "Correct";
        ChoiceMade = num;

        // hide other options
        int i = 0;
        foreach (var button in AnswerButtons)
        {
            if (i != num) button.gameObject.SetActive(false);
            i++;
        }
    }

    /// <summary>
    /// Call this function to reset the quiz panel.
    /// </summary>
    public void ResetQuiz()
    {
        Textbox.text = title.ToUpper();
        ChoiceMade = -1;
        foreach (var button in AnswerButtons)
        {
            button.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Setup buttons. Will reset their On Click listeners.
    /// </summary>
    [ContextMenu("Setup Answer Buttons")]
    public void SetupButtons()
    {
        int i = 0;
        foreach (var button in AnswerButtons)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => ChooseOption(i));
            i++;
        }
    }
}
