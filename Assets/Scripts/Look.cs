using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour {

	float newX, newZ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		newX = transform.position.x;
		newZ = transform.position.z;
		transform.position = new Vector3  (newX,0,newZ);
	}
}
