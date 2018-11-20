using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TODO
/// </summary>
[CreateAssetMenu(fileName="MultipleChoice", menuName="Quiz/Multiple Choice")]
public class MultipleChoice : QuizContent {
    public List<Option> QuizOptions = new List<Option>();

    [Serializable]
    public class Option {
        public string optionText;
        public bool IsCorrect;
    }
}
