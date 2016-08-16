using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
	private Ray ray;
	private RaycastHit hit;
	private CameraController player;
	public bool isGoal=false;
	public int color=0;

	void Start(){
		player=(CameraController)GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
	}

	void Update(){
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit)){
			player.hoverOn(gameObject);
		}
	}

	void OnMouseDown() {
		if (Input.GetKey ("mouse 0")) {
			if(player.getCurrent().Equals(gameObject)){
				player.clickSelf();
			}else {
				var success = player.setNewTarget(gameObject);
			}
		}
	}

	public void flash(){
		//TODO
	}
}
