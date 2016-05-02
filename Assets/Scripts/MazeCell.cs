using UnityEngine;

public class MazeCell : MonoBehaviour {
	public IntVector2 coordinates;

	private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];
	private bool dug = false;
	private bool shouldHaveChest;
	public float chestThreahold = 0.1f;
	private bool shouldHaveTreasure;
	public Material digMaterial;

	private int initializedEdgeCount;

	public MazeRoom room;
	public GameObject capsule;


	public void Initialize (MazeRoom room) {
		room.Add(this);
		transform.GetChild(0).GetComponent<Renderer>().material = room.settings.floorMaterial;
	}

	public MazeCellEdge GetEdge (MazeDirection direction) {
		return edges[(int)direction];
	}

	public bool IsFullyInitialized {
		get {
			return initializedEdgeCount == MazeDirections.Count;
		}
	}

	/*public void Show () {
		gameObject.SetActive(true);
	}

	public void Hide () {
		gameObject.SetActive(false);
	}*/

	public void SetEdge (MazeDirection direction, MazeCellEdge edge) {
		edges[(int)direction] = edge;
		initializedEdgeCount += 1;
	}

	public MazeDirection RandomUninitializedDirection {
		get {
			int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
			for (int i = 0; i < MazeDirections.Count; i++) {
				if (edges[i] == null) {
					if (skips == 0) {
						return (MazeDirection)i;
					}
					skips -= 1;
				}
			}
			throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
		}
	}

	public void findTreasure(){
		if (!dug) {


			if (Random.Range (0, 1f) < chestThreahold) {
				GameObject cap = Instantiate (capsule, transform.position + new Vector3 (0f, 0.2f, 0f), transform.rotation) as GameObject;
				cap.transform.parent = transform;
			}
			dug = true;
			this.gameObject.transform.GetChild(0).GetComponent<Renderer>().material = digMaterial;

		}
	}
}
