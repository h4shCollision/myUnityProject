using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class LevelsManager{
	private static int curLvl;

	public static void restart(){
		
	}

	public static void win(){
		curLvl+=1;
		SceneManager.LoadScene("main");
	}

	public static void start(){
		curLvl=1;
		SceneManager.LoadScene("main");
	}

	public static int getCurrentLevel(){
		return curLvl;
	}
}
