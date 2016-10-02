using System;
using UnityEngine;
using SimpleJSON;

public class ObjectData{
	public int color;
	public float x,y,z;
	public Boolean isGoal;
	public Boolean target;
	public Vector3 getPos(){
		return new Vector3(x,y,z);
	}
	public ObjectData(SimpleJSON.JSONNode json){
		color=json["color"].AsInt;
		isGoal=json["isGoal"].AsBool;
		target=json["target"].AsBool;
		x=json["position"][0].AsFloat;		
		y=json["position"][1].AsFloat;
		z=json["position"][2].AsFloat;
	}
}
