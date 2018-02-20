using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

	private static int gamescore;
	public GameObject score;
	private Text text;
	// Use this for initialization
	void Start () {
		text = score.GetComponent<Text> ();
		text.text = "Score : " + gamescore;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			Destroy (gameObject);
			gamescore += 50;
			text = score.GetComponent<Text> ();
			text.text = "Score : " + gamescore;
		}
	}
}
