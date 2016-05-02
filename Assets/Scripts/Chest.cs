using UnityEngine;
using System.Collections;


public class Chest : MonoBehaviour {
	public float treasureThreahold = 0.9f;
	private bool shouldHaveTreasure;
	private bool open = false;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void openChest(){
		if (!open) {

			Destroy(this.gameObject.transform.GetChild(0).gameObject);

			if (Random.Range (0, 1f) < treasureThreahold) {
				//add money
			}
			open= true;
			Invoke ("DestroyLater", 3);

		}
	}

	public void DestroyLater(){
		DestroyObject (this.gameObject);
	}

}