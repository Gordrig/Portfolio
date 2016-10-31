using UnityEngine;
using System.Collections;

public class CreateBackground : MonoBehaviour {

	//public Transform[] items;
	private Vector3 position;
	private int ID, iDistance, temp;
	private float distance;
	private bool started;
	//public int[,] blockArr;
	//public Transform[] itemsArr;
	public bool update;
	//private Random rand;
	//public int lX, lY, size;
	public Values V;

	// Use this for initialization
	void Start () {
		V = GameObject.Find("Globals").GetComponent<Values>();
		started = false;
		/*for (int y = 0; y < V.blockArr.GetLength(1); y++){
			for (int x = 0; x < V.blockArr.GetLength(0); x++) {
				//distance from the center of the map
				distance = Mathf.Sqrt(Mathf.Pow(x-(V.lX/2), 2)+ Mathf.Pow(y - (V.lY/2), 2))/(V.size/2);
				//determine relative distance from center
				iDistance = (int)(distance*V.items.Length);
				// randomize ID
				ID = Random.Range(iDistance - 1, iDistance + 1);
				if (ID < 0) {ID = 0;}
				// set ID
				V.blockArr[x,y] = ID;
			}
		}*/
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!started) {
			for (int y = 0; y < V.blockArr.GetLength(1); y++){
				for (int x = 0; x < V.blockArr.GetLength(0); x++) {
					//distance from the center of the map
					distance = Mathf.Sqrt(Mathf.Pow(x-(V.lX/2), 2)+ Mathf.Pow(y - (V.lY/2), 2))/(V.size/2);
					//determine relative distance from center
					iDistance = (int)(distance*V.items.Length);
					// randomize ID
					ID = Random.Range(iDistance - 1, iDistance + 1);
					if (ID < 0) {ID = 0;}
					// set ID
					V.blockArr[x,y] = ID;
				}
			}
			started = true;
		}
		if (update) {
			// instansiate blocks on the map based on ID
			for (int y = 0; y < V.blockArr.GetLength(0); y++) {
				for (int x = 0; x < V.blockArr.GetLength(1); x++) {
					try
					{V.itemsArr[x,y] = Instantiate(V.items[V.blockArr[x,y]], new Vector3(x,0,y), Quaternion.Euler(new Vector3(90,0,0))) as Transform;}
					catch
					{V.itemsArr[x,y] = Instantiate(V.items[V.items.Length-1], new Vector3(x,0,y), Quaternion.Euler(new Vector3(90,0,0))) as Transform;}
				}
			}
			update = false;
				}
	}

	void UpdateBackground ()
	{

	}
}
