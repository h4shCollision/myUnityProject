using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour{
	public const int DIRECT_REACHABLE=1, NOT_DIRECT_REACHABLE=2, INDIRECT_REACHABLE=3;
	private bool animating;
	private const float ANIMATION_SPEED=3;
	private Vector3 animationAxis;
	public Material direct, notDirect, inDirect;

	void Start(){
		disable();
	}

	void FixedUpdate(){
//		if(animating){
//			transform.RotateAround(transform.position, animationAxis, ANIMATION_SPEED);
//		}
	}

	public void enable(Transform cam, int option){
		animating=true;
		Vector3 displ=cam.position-transform.position;
		transform.RotateAround(transform.position, Vector3.Cross(Vector3.forward, displ), Vector3.Angle(Vector3.forward, displ));
		gameObject.SetActive(true);
		animationAxis=transform.rotation*Vector3.right;
		if(option==DIRECT_REACHABLE){
			GetComponent<MeshRenderer>().material=direct;
		} else if(option==INDIRECT_REACHABLE){
			GetComponent<MeshRenderer>().material=inDirect;
		} else if(option==NOT_DIRECT_REACHABLE){
			GetComponent<MeshRenderer>().material=notDirect;
		}
	}

	public void disable(){
		animating=false;
		gameObject.SetActive(false);
		transform.rotation=Quaternion.identity;
	}
}
