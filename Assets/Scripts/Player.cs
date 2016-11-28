using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject headCamera;
//	float oldY;
	// Use this for initialization
	void Start () {
//		oldY = headCamera.transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update () {
//		float newY = headCamera.transform.rotation.y;
//
//		float diffY = newY - oldY;
//
//		Debug.Log ("y:"+diffY);
//		Debug.Log (transform.rotation.eulerAngles);
//		Vector3 lookVector = new Vector3 (0, diffY,0);
		transform.LookAt (headCamera.transform, Vector3.up);

//		oldY = headCamera.transform.rotation.y;
	}

}
