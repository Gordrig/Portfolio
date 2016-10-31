using UnityEngine;
using System.Collections;

public class A_star : MonoBehaviour {

	public ArrayList openList, closedList;
	private int itemp;
	private Values V;
	private float bestdist, currdist;
	private bool closed, open, found;
	private Node temp, target, start, destination;
	private GameObject player;
	public float speed;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("Player");
		V = GameObject.Find ("Globals").GetComponent<Values> ();
		openList = new ArrayList ();
		closedList = new ArrayList ();
	}

	// simple script to move the enemy towards the destination node
	void Move (Transform trans)
	{
		this.gameObject.transform.position += new Vector3 (trans.position.x/60, 0, trans.position.y/60);
	}

	// simple function to find the distance between two positions
	float FindDistance (Transform first, Transform second)
	{
		return Mathf.Sqrt(Mathf.Pow((first.position.x - second.position.x),2) + Mathf.Pow((first.position.z - second.position.z),2));
	}

	// finds the node closest to this gameobject's position
	Node FindCloseNode (Transform trans)
	{
		Node Ntemp = V.nodeArr[0,0];
		bestdist = 0;
		for (int y = 0; y < V.lY; y++) {
			for (int x = 0; x < V.lX; x++) {
				currdist = FindDistance(trans, V.itemsArr[x,y]);
				if (currdist < bestdist)
				{
					Ntemp = V.itemsArr[x,y].GetComponent<Node>();
				}
			}
		}
		return Ntemp;
	}

	// checks the g value of a node and sets it to the lowest value (also sets parentage)
	void CheckG (Node primary, Node toCheck)
	{
		foreach (Node n in closedList)
		{
			if ((toCheck.x == n.x) && (toCheck.y == n.y)) {closed = true;}
		}
		if (!closed)
		{
			foreach (Node n in openList)
			{
				if ((toCheck.x == n.x) && (toCheck.y == n.y)) {open = true;}
			}
			if (open)
			{
				if (toCheck.G > (primary.G + (FindDistance(primary.gameObject.transform, toCheck.gameObject.transform)))){
					toCheck.G = (primary.G + (FindDistance(primary.gameObject.transform, toCheck.gameObject.transform)));
					toCheck.parent = primary;
				}
			}
			else
			{
				openList.Add(toCheck);
				toCheck.G = primary.G + FindDistance(primary.gameObject.transform, toCheck.gameObject.transform);
				toCheck.parent = primary;
			}
		}
	}

	// given a node, checks all neighboring nodes and calls CheckG for them.
	void SetGValues (Node Ntemp)
	{
		Node Ntemp2;
						try {
								Ntemp2 = V.nodeArr [Ntemp.x + 1, Ntemp.y + 1]; 	//1
								CheckG (Ntemp, Ntemp2);
						} catch {
						}
						try {
								Ntemp2 = V.nodeArr [Ntemp.x + 1, Ntemp.y];		//2
								CheckG (Ntemp, Ntemp2);
						} catch {
						}
						try {
								Ntemp2 = V.nodeArr [Ntemp.x, Ntemp.y + 1];		//3
								CheckG (Ntemp, Ntemp2);
						} catch {
						}
						try {
								Ntemp2 = V.nodeArr [Ntemp.x - 1, Ntemp.y + 1];	//4
								CheckG (Ntemp, Ntemp2);
						} catch {
						}
						try {
								Ntemp2 = V.nodeArr [Ntemp.x + 1, Ntemp.y - 1];	//5
								CheckG (Ntemp, Ntemp2);
						} catch {
						}
						try {
								Ntemp2 = V.nodeArr [Ntemp.x - 1, Ntemp.y - 1];	//6
								CheckG (Ntemp, Ntemp2);
						} catch {
						}
						try {
								Ntemp2 = V.nodeArr [Ntemp.x - 1, Ntemp.y];	//7
								CheckG (Ntemp, Ntemp2);
						} catch {
						}
						try {
								Ntemp2 = V.nodeArr [Ntemp.x, Ntemp.y - 1];	//8
								CheckG (Ntemp, Ntemp2);
						} catch {
						}
		openList.Remove (Ntemp);
		closedList.Add (Ntemp);
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		target = FindCloseNode (player.transform);
		start = FindCloseNode(this.gameObject.transform);
		SetGValues (start);

		while (!found && (openList.Count > 0))
		{
			itemp = int.MaxValue;
			foreach (Node n in openList) 
			{
				if ((n.H < itemp) || (n.H < temp.H))
				{
					temp = n;
					itemp = -int.MaxValue;
				}
			}
			if ((temp.x == target.x) && (temp.y == target.y)) 
			{
				found = true;
			}
			else 
			{
				SetGValues (temp);
			}
		}
		//need to trace the path back to the start node and get the next node in the path
		temp = target;
		while ((temp.parent.x != start.x) || (temp.parent.y != start.y)) {
			temp = temp.parent;
				}
		Move (temp.gameObject.transform);
	}
}
