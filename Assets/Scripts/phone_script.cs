using UnityEngine;
using System.Collections;

public class phone_script : MonoBehaviour {

    public GameObject me,it;
    private bool tog;
    private bool isOpen;
    private bool movong;
    public float speed = 100f;
    private bool toClose;
    private bool toOpen;
    private Vector3 sp, ep;
    private bool A, B, C,D,E,F;


    // Use this for initialization
    void Start () {
        Vector3 npos = new Vector3(me.transform.position.x, me.transform.position.y-2.5f, me.transform.position.z);
        transform.position =  npos;
        //y+6  x-1  z-0.46
        sp = npos;

        ep = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
    }
	
	
    
    // Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("p"))
        {
            sp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            ep = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z - 1.5f);

            /*   if (tog == false)
               {
                  // transform.Rotate(new Vector3(90, 0, 0));
                // // // //transform.position = new Vector3(me.transform.position.x - 0.1f, me.transform.position.y + 6.2f, me.transform.position.z + 0.9f);
                  // transform.position = new Vector3(me.transform.position.x, me.transform.position.y, me.transform.position.z);
                  // tog = true;
               }
               else
               {
                //   transform.Rotate(new Vector3(-90, 0, 0));
                //   transform.position = new Vector3(me.transform.position.x, me.transform.position.y-2.5f, me.transform.position.z);
                 //  tog = false;
               }
               */

            if (isOpen==true && movong == false)
            {
                movong = true;
                toClose = true;

            }
            else if (movong == false)
            {
                movong = true;
                toOpen = true;

            }


        }






        if (isOpen == false && toOpen == true)//opening
        {
            //animation
            //transform.Translate(new Vector3(0f,1f,2) * Time.deltaTime);
            //transform.position.y>=6.2f && transform.position.z >= -0.4f

            //if (transform.position.y < 6.0f&&B==false)
            /*   if (transform.position.y < me.transform.position.y && B == false)
               {
                   transform.position += transform.up * Time.deltaTime ;
               }
               else if (transform.position.y >= ep.y)
               {

                   B = true;
               }

               if (transform.position.z < me.transform.position.z&&C==false)
               {
                   transform.position += transform.forward * Time.deltaTime;
               }
               else if (transform.position.y >= 6.2f)
               {
                   C = true;
               }
   */

            if (transform.position == me.transform.position)
            {
                B = true;
                C = true;

            }
            else {
                transform.position = Vector3.MoveTowards(transform.position,me.transform.position,Time.deltaTime*2);

            }
            if (transform.eulerAngles.x < 80 && A==false)
            {
              //  transform.Rotate(new Vector3(1, 0, 0), speed * Time.deltaTime);
                
            }
            else if (transform.eulerAngles.x >=80)
            {
               // A = true;
               
            } 
            
                   
            if(B && C )//opened
            {
                              
                isOpen = true;
                toOpen = false;
                movong = false;
                A = false;
                B = false;
                C = false;

            }
        }





        //TO KEEP INSIDE
        if (isOpen == true && toClose == true)
        {

            if (transform.position == it.transform.position)
            {
                E = true;
                F = true;

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,it.transform.position, Time.deltaTime * 2);

            }
            if (transform.eulerAngles.x >1 && D == false)
            {
               // transform.Rotate(new Vector3(-1, 0, 0), speed * Time.deltaTime);
               

            }
            else if (transform.eulerAngles.x <= 5)
            {
                //D = true;
                
            }


            if (E && F)//closed
            {
                isOpen = false;
                toClose = false;
                movong = false;
                D = false;
                E = false;
                F = false;
            }
        }






    }



}

