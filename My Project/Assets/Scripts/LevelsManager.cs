using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class LevelsManager{
	public static void restart(){
		
	}

	public static void win(){
		SceneManager.LoadScene("main");
	}

	public static void start(){
		SceneManager.LoadScene("main");
	}
}
