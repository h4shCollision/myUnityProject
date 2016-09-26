using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour{
	private Ray ray;
	private RaycastHit hit;
	private CameraController player;
	public bool isGoal=false;
	public int color=0;
	private Renderer rend;
	private static Material reachable;
	private bool hover=false;

	void Start(){
		player=(CameraController)GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
		rend=GetComponent<Renderer>();
		rend.enabled=true;
	}

	void Update(){
		ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit)){
			if(!hover){
				player.hoverOn(gameObject);
				hover=true;
			}
		} else{
			if(hover){
				player.paint();
				hover=false;
			}
		}
	}

	public void setData(ObjectData data){
		color=data.color;
		isGoal=data.isGoal;
		transform.position=data.getPos();
	}

	void OnMouseDown(){
		if(Input.GetKey("mouse 0")){
			if(player.getCurrent().Equals(gameObject)){
				player.clickSelf();
			} else{
				var success=player.setNewTarget(gameObject);
			}
		}
	}

	public void flash(){
		rend.material=reachable;
	}

	public void setObjectMaterial(Material m){
		if(rend!=null)
			rend.material=m;
	}

	public static void setReachableMaterial(Material m){
		reachable=m;
	}
}
