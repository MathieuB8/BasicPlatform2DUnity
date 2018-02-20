using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundFollowCamera : MonoBehaviour {

	Transform target;

     // Use this for initialization
     void Start () {
     }
     
     // Update is called once per frame
     void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z );
     }
}
