using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public void SetLocation (MazeCell cell) {
		transform.localPosition = cell.transform.localPosition;
	}


	public void OnTriggerEnter (Collider hit) 
	{

		/*if(Input.GetKeyDown("f") && GetComponent<Collider>().gameObject.tag=="door" )
		{*/
		Collider col = hit.GetComponent<Collider> ();
		GameObject game = col.gameObject.transform.parent.gameObject.transform.parent.gameObject;
		MazeDoor door = game.GetComponent<MazeDoor> ();
			door.OnPlayerEntered();
		/*}*/

	}
}
