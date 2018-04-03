using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainToggle : MonoBehaviour {
	public GameObject Terrain; 
	public GameObject Map; 	

	public void Toggle_Changed(bool val){
		Terrain.SetActive (!val); 
		Map.SetActive (val);	
	}
}
