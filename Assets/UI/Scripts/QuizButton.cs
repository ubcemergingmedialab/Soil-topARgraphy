using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Obsolete("To be replaced by UiQuizPanel.")]
public class QuizButton : MonoBehaviour
{
    [Serializable]
    public class QuizButtonEntry
    {
        /// <summary>Button the user can tap</summary>
        /// <remarks>Set in the inspector</remarks>
        public Button button = null;
        /// <summary>Response shown after `button` is tapped</summary>
        public string response;

        public QuizButtonEntry(string response)
        {
            this.response = response;
        }
    }


    /// <summary>Default title, used when quiz is reset.</summary>
    public string title = "Hey, want to take a quiz?";

    /// <summary>Reference to response textbox</summary>
    public Text Textbox;

    /// <summary>
    /// List of buttons and possible responses when an answer is clicked.
    /// When an answer is selected, all other buttons will be hidden.
    /// </summary>
    public List<QuizButtonEntry> Answers = new List<QuizButtonEntry>() {
        new QuizButtonEntry("Yeees"),
        new QuizButtonEntry("Aww why not?"),
        new QuizButtonEntry("please?"),
        new QuizButtonEntry("CORRECT! A+ for you")
    };

    /// <summary>Displays the index of the selected answer in the inspector.</summary>
    public int ChoiceMade = -1;

    /// <summary>
    /// Click listener assigned to the answer buttons. Should be called
    /// with the index of the button.
    /// </summary>
    /// <param name="num">index of the option in `Answers`</param>
    public void ChooseOption(int num)
    {
        Textbox.text = num < Answers.Count ? Answers[num].response : "Correct";
        ChoiceMade = num;

        var query = Answers
            .Where((answer, i) => i != num)
            .Select(answer => answer.button.gameObject);

        // hide other options
        foreach (var buttonObject in query)
        {
            buttonObject.SetActive(false);
        }
    }

    /// <summary>
    /// Call this function to reset the quiz panel.
    /// </summary>
    public void ResetQuiz()
    {
        Textbox.text = title.ToUpper();
        ChoiceMade = -1;

        var query = from answer in Answers select answer.button.gameObject;

        foreach (var button in query)
        {
            button.SetActive(true);
        }
    }

    /// <summary>
    /// Setup buttons. Will reset their On Click listeners.
    /// </summary>
    [ContextMenu("Setup Answer Buttons")]
    public void SetupButtons()
    {
        var query = Answers.Select((answer, index) => new { index, button = answer.button });

        foreach (var item in query)
        {
            item.button.onClick.RemoveAllListeners();
            item.button.onClick.AddListener(() => ChooseOption(item.index));
        }
    }
}
