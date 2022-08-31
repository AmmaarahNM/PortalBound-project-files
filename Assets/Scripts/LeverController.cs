using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    GameObject handle;
    GameObject check;
    Vector3 currentPos;
    Vector3 newPos;
    bool leverReach;
    bool open = false;
    public GameObject entrance;
 
    public LayerMask triggerLayer;
    public GameObject leverUI;

    public AudioSource gateOpens;
    
    // Start is called before the first frame update
    void Start()
    {
        handle = transform.GetChild(1).gameObject;
        check = transform.GetChild(2).gameObject;
        currentPos = new Vector3(-89.98f, 0, 0);
        newPos = new Vector3(-20f, 90, -90);

    }

    // Update is called once per frame
    void Update()
    {
        leverReach = Physics.CheckSphere(check.transform.position, 1, triggerLayer);
        if (leverReach == true)
        {
            Debug.Log("raannggeee");
            leverUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))  
            {
                gateOpens.Play();
                //Debug.Log("truuuu");
                if (open == false)
                {
                    handle.transform.localEulerAngles = newPos;
                    open = true;
                    entrance.SetActive(false);
                }

                else
                {
                    handle.transform.localEulerAngles = currentPos;
                    open = false;
                    entrance.SetActive(true);
                }

            }

        }

        else
        {
            leverUI.SetActive(false);

        }
        
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("CharCollision");
            //enable prompt UI
            leverReach = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //disable prompt UI
            leverReach = false;
        }
    }
}
