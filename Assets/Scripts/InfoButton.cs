using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void changeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
