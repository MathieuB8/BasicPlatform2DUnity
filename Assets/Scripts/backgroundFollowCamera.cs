using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//unused, useless
public class backgroundFollowCamera : MonoBehaviour {

	Transform target;
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z );
	}
}
