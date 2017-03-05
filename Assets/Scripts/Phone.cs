using UnityEngine;
using System.Collections;

public class Phone : MonoBehaviour {

    public GameObject me,it;
    private bool isOpen;
    private bool moving;
    public float speed = 100f;
    private bool toClose;
    private bool toOpen;
	private Vector3 startPos;
    private bool opened, closed;


    // Use this for initialization
    void Start () {
		startPos = new Vector3(me.transform.position.x, me.transform.position.y-2.5f, me.transform.position.z);
		transform.position =  startPos;
    }
	
	
    
    // Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown("Fire2")) {
//            sp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
//            ep = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z - 1.5f);

			if (isOpen == true && moving == false) {
				moving = true;
				toClose = true;
			} else if (isOpen == false && moving == false) {
				moving = true;
				toOpen = true;
			}
        }
		if (isOpen == false && toOpen == true) { //opening 
            //animation
          	if (transform.position == me.transform.position) {
				opened = true;
			} else {
                transform.position = Vector3.MoveTowards(transform.position,me.transform.position,Time.deltaTime*2);
            }
			if(opened) { //opened
				isOpen = true;
                toOpen = false;
                moving = false;
				opened = false;
			}
        }
        //TO KEEP INSIDE
		if (isOpen == true && toClose == true) {
            if (transform.position == it.transform.position) {
				closed = true;
			} else {
                transform.position = Vector3.MoveTowards(transform.position,it.transform.position, Time.deltaTime * 2);
            }
			if (closed) { //closed
                isOpen = false;
                toClose = false;
                moving = false;
				closed = false;
            }
        }
	}



}

