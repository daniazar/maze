﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public Player playerPrefab;

	private Player playerInstance;

	private void Start () {
		StartCoroutine(BeginGame());
	}

	private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	}

	public Maze mazePrefab;

	private Maze mazeInstance;

	private IEnumerator BeginGame () {
		Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
		Camera.main.clearFlags = CameraClearFlags.Skybox;

		mazeInstance = Instantiate(mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate());
		playerInstance = Instantiate(playerPrefab) as Player;
		playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
		Camera.main.clearFlags = CameraClearFlags.Depth;

		Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);

	}

	private void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		if (playerInstance != null) {
			Destroy(playerInstance.gameObject);
		}
		StartCoroutine(BeginGame());	}
}