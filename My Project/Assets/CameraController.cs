using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour{

	public float rotationAmount;

	private bool isMoving=false;
	public GameObject target, current;
	private Vector3 iniPos, displ;
	public  float stoppingRadius=3.5f, reachable=10f;
	private float progress, moveForward=0;
	public GameObject[] allObjects;
	public Material[] materials;

	void Start(){
		current=null;
		prepareAnim();
		paint();
	}

	void paint(){
		for(int i=0; i<allObjects.Length; i++){
			Renderer renderer=(Renderer)allObjects[i].GetComponent<Renderer>();
			Material material=materials[((Entity)allObjects[i].GetComponent<Entity>()).color];
			renderer.material=material;
		}
	}

	void FixedUpdate(){
		if(isMoving){
			progress+=Time.fixedDeltaTime;
			if(progress>=1f){
				transform.position=iniPos+displ;
				stopAnim();
			} else
				transform.position=iniPos+progress*displ;
		}
	}

	void Update(){
		handleRotation();
		handleForward();
	}

	//TODO: new coordinate system!!
	void handleRotation(){
		if(isMoving)
			return;
		int rotx=0, roty=0, rotz=0;
		if(Input.GetKey(KeyCode.UpArrow))
			roty+=1;
		if(Input.GetKey(KeyCode.DownArrow))
			roty-=1;
		transform.Rotate(Vector3.left, roty);
		if(Input.GetKey(KeyCode.LeftArrow))
			rotx-=1;
		if(Input.GetKey(KeyCode.RightArrow))
			rotx+=1;
		transform.Rotate(Vector3.up, rotx);
		if(Input.GetKey(KeyCode.A))
			rotz+=1;
		if(Input.GetKey(KeyCode.D))
			rotz-=1;
		transform.Rotate(Vector3.forward, rotz);
	}

	void handleForward(){
		if(moveForward>0){
			moveForward-=Time.deltaTime;
			transform.RotateAround(current.transform.position, transform.right, 0.5f);
			if(moveForward<=0){
				moveForward=0;		
			}
		}
	}

	public void hoverOn(GameObject obj){
		if(isMoving){
			return;
		}
		for(int i=0; i<allObjects.Length; i++){
			if(Vector3.Distance(obj.transform.position, allObjects[i].transform.position)<=reachable && obj!=allObjects[i] && obj!=current){
				((Entity)allObjects[i].GetComponent<Entity>()).flash();
			}
		}
	}

	//return true if successful
	public bool setNewTarget(GameObject other){
		if(isMoving)
			return false;
		if(Vector3.Distance(current.transform.position, other.transform.position)>reachable){
			return false;
		}
		target=other;
		prepareAnim();
		return true;
	}

	private void prepareAnim(){
		if(isMoving)
			return;
		iniPos=transform.position;
		progress=0;
		displ=target.transform.position-iniPos;
		float dist=Vector3.Magnitude(displ);
		if(dist<stoppingRadius)
			displ=Vector3.zero;
		else{
			displ*=(dist-stoppingRadius)/dist;
		}
		isMoving=true;
	}

	private void stopAnim(){
		if(!isMoving)
			return;
		isMoving=false;
		current=target;
		if(current.GetComponent<Entity>().isGoal){
			LevelsManager.win();
		}
	}

	public GameObject getCurrent(){
		return current;
	}

	public void clickSelf(){
		if(moveForward==0)
			moveForward=0.5f;
	}
}
