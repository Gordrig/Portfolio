using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	public int ID, x, y;
	public float H,G,F;
	public Node parent;
	public Transform position;

	// Use this for initialization
	void Start () {
		H = 0;
		G = 0;
		F = 0;
		ID = 0;
		x = 0;
		y = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
