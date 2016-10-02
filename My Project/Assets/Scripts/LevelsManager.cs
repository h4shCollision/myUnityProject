using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using SimpleJSON;

public static class LevelsManager{
	private static int curLvl;
	private static int maxLvl;

	public static void init(){
		TextAsset asset=Resources.Load<TextAsset>("metadata") as TextAsset;
		var metadata=JSONNode.Parse(asset.text);
		maxLvl=metadata["numlevels"].AsInt;
	}

	public static void restart(){
		
	}

	public static void menu(){
		SceneManager.LoadScene("menu");
	}

	public static void win(){
		curLvl+=1;
		curLvl=Mathf.Min(curLvl, maxLvl);
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
