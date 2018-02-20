using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public int maxPlatforms = 20;
	public GameObject platform;
	public GameObject coin;
	public float horizontalMin = 6.5f;
	public float horizontalMax = 14f; // spawn plateform to right of first platform and max distance from the right is 6.5 and 14f...
	public float verticalMin = -6f; // spawn above or below of 6
	public float verticalMax = 6f;
	public float verticalCoinMax = 9f;
	public float verticalCoinMin = 2f;
	private Vector2 originPosition;
	// Use this for initialization
	void Start () {
		originPosition = transform.position;
		Spawn ();

	}
	
	// Update is called once per frame
	void Spawn () {
		for (int i = 0; i < maxPlatforms; i++) {
			Vector2 randomPosition = originPosition + new Vector2 (Random.Range (horizontalMin, horizontalMax), Random.Range (verticalMin, verticalMax));
			Instantiate (platform, randomPosition, Quaternion.identity); // quarternion identity means no rotation
			originPosition = randomPosition;
			Instantiate (coin, randomPosition + new Vector2 (0,Random.Range(verticalCoinMin,verticalCoinMax)), Quaternion.identity); // quarternion identity means no rotation
		}
			
	}
}
