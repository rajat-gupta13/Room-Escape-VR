using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {
	private int counter = 0;
	public GameObject text1, text2, text3, text4;
	// Use this for initialization
	void Start () {
		text1.SetActive (true);
		text2.SetActive (false);
		text3.SetActive (false);
		text4.SetActive (false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.anyKeyDown && counter < 4) {
			switch (counter) {
			case 0:
				text1.SetActive (false);
				text2.SetActive (true);
				text3.SetActive (false);
				text4.SetActive (false);
				counter++;
				break;
			case 1:
				text1.SetActive (false);
				text2.SetActive (false);
				text3.SetActive (true);
				text4.SetActive (false);
				counter++;
				break;
			case 2:
				text1.SetActive (false);
				text2.SetActive (false);
				text3.SetActive (false);
				text4.SetActive (true);
				counter++;
				break;
			case 3:
				text1.SetActive (false);
				text2.SetActive (false);
				text3.SetActive (false);
				text4.SetActive (false);
				counter++;
				SceneManager.LoadScene (2);
				break;
			}
		}
	}
}
