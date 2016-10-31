using UnityEngine;
using System.Collections;

public class PlayerSupportScript : MonoBehaviour {

	private GameObject player, globals;
	//CreateBackground createbackground;
	public bool spawn;
	private Values V;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		globals = GameObject.Find ("Globals");
		V = globals.GetComponent<Values> ();
		//createbackground = globals.GetComponent<CreateBackground> ();
	}
	
	// Update is called once per frame
	void Update () {
	 if (spawn) {
			player.transform.position = new Vector3 (V.blockArr.GetLength(0)/2, 3, V.blockArr.GetLength(1)/2);
			spawn = false;
				}
	}
}
