using UnityEngine;
using System.Collections;

public class Dig : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.F)) {
			var up = transform.TransformDirection (Vector3.up);
			//note the use of var as the type. This is because in c# you 
			// can have lamda functions which open up the use of untyped variables
			//these variables can only live INSIDE a function. 
			RaycastHit hit;
			Debug.DrawRay (transform.position, -up , Color.green);

			if (Physics.Raycast (transform.position, -up, out hit, 2)) {
				GameObject game = hit.collider.gameObject.transform.parent.gameObject;
				MazeCell cell = game.GetComponent<MazeCell> ();
				cell.findTreasure ();
				}
			}

		if (Input.GetKey (KeyCode.G)) {
			var forward = transform.forward;
			//note the use of var as the type. This is because in c# you 
			// can have lamda functions which open up the use of untyped variables
			//these variables can only live INSIDE a function. 
			RaycastHit hit;
			Debug.DrawRay (transform.position, forward + new Vector3(0f,0.2f,0f), Color.green);

			if (Physics.Raycast (transform.position, forward + new Vector3(0f,0.2f,0f), out hit, 2)) {
				GameObject game = hit.collider.gameObject.transform.parent.gameObject;
				Chest chest = game.GetComponent<Chest> ();
				if(chest)
					chest.openChest();
			}

		}

		}


	}
