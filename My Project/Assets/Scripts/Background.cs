using UnityEngine;
using System.Collections;
using System.Linq;

public class Background : MonoBehaviour {
	public int[] Tris = new int[100];
	int temp;
	void Start () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.triangles = mesh.triangles.Reverse().ToArray();
	}
}
