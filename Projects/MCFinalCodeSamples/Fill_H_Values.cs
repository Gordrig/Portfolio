using UnityEngine;
using System.Collections;

public class Fill_H_Values : MonoBehaviour {

	private Values V;
	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("Player");
		V = GameObject.Find ("Globals").GetComponent<Values> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		for (int y = 0; y < V.lY; y++) 
		{
			for (int x = 0; x < V.lX; x++)
			{
				V.itemsArr[x,y].GetComponent<Node>().H = Mathf.Abs(V.itemsArr[x,y].transform.position.x - player.transform.position.x) + Mathf.Abs(V.itemsArr[x,y].transform.position.z - player.transform.position.z);
			}
		}
	}
}
