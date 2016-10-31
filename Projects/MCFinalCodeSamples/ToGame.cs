using UnityEngine;
using System.Collections;

public class ToGame : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider myTrigger)
	{
		if (myTrigger.gameObject == player) 
		{
			Application.LoadLevel ("GameScene");
		}
	}
}
