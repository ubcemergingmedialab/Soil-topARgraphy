using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class quizButton : MonoBehaviour {

	public GameObject Textbox;  
	public GameObject Answer1; 
	public GameObject Answer2; 
	public GameObject Answer3; 
	public GameObject Answer4; 
	public int ChoiceMade; 

	public void ChoiceOption1 () {
		Textbox.GetComponent<Text>().text = "Yeees"; 
		ChoiceMade = 1; 
	}

	public void ChoiceOption2 () {
		Textbox.GetComponent<Text>().text = "Aww why not?"; 
		ChoiceMade = 2; 
	}

	public void ChoiceOption3 () {
		Textbox.GetComponent<Text>().text = "please?"; 
		ChoiceMade = 3; 
	}

	public void ChoiceOption4 () {
		Textbox.GetComponent<Text>().text = "CORRECT! A+ for you"; 
		ChoiceMade = 4; 
	}

	void Update() {
		if (ChoiceMade >= 1) {
			Answer1.SetActive (false);  // hide object when selected
			Answer2.SetActive (false); 
			Answer3.SetActive (false); 
			Answer4.SetActive (false); 
		}
	}


}
