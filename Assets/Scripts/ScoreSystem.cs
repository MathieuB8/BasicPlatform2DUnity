using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

	private static int gamescore = 0;
	public GameObject score;
	private Text text;

	// Use this for initialization
	void Start () {
		gamescore = 0;
		text.text = "Score : 0";
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Coin")) {
			other.gameObject.tag = "UsedCoin";
			gamescore += 50;
			text = score.GetComponent<Text> ();
			text.text = "Score : " + gamescore;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
