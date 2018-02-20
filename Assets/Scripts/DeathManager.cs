using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			//Application.LoadLevel (Application.loadedLevel ());
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
