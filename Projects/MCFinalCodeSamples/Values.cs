using UnityEngine;
using System.Collections;

public class Values : MonoBehaviour {

	public Node[,] nodeArr;
	private bool started;
	public Transform[] items;
	public int[,] blockArr;
	public Transform[,] itemsArr;
	public int lX, lY, size;
	public Random rand;

	void Start ()
	{
		nodeArr = new Node[lX, lY];
		blockArr = new int[lX, lY];
		itemsArr = new Transform[lX, lY];
		started = false;
	}

	void Update ()
	{
		if (!started) {
			for (int y = 0; y < lY; y++)
			{
				for (int x = 0; x < lX; x++)
				{
					nodeArr[x,y] = itemsArr[x,y].GetComponent<Node>();
				}
			}
			started = true;
				}
	}
}
