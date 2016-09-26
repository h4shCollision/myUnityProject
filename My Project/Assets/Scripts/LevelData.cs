using System;
using System.IO;
using SimpleJSON;

public class LevelData{

	public ObjectData[] objects;

	public LevelData(String json){
		var n=JSONNode.Parse(json);
		var objectJsons=n["objects"];
		objects=new ObjectData[objectJsons.AsArray.Count];
		for(int i=0; i<objects.Length; i++){
			objects[i]=new ObjectData(objectJsons[i]);
		}
	}

	public int getNumObjects(){
		if (objects == null){
			return 0;
		}
		return objects.Length;
	}


	public ObjectData getData(int i){
		return objects[i];
	}
}
