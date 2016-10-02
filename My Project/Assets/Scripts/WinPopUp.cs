using UnityEngine;
using System.Collections;

public class WinPopUp : MonoBehaviour{

	void Start(){
		GetComponent<Canvas>().enabled=false;
	}

	void Update(){
	
	}

	public void show(){
		GetComponent<Canvas>().enabled=true;
	}

	public void next(){
		LevelsManager.win();
	}

	public void restart(){
		LevelsManager.restart();
	}

	public void menu(){
		LevelsManager.menu();
	}
}
