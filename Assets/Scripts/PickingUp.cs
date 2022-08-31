using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : MonoBehaviour
{
    public GameObject pickUpLocation;
    bool pickUpInRange;
    public LayerMask triggerLayer;
    public GameObject pickUpUI;
    Vector3 originalScale;
    //public MovingWalls MW;
    void Start()
    {
        originalScale = transform.localScale;
 
    }

    // Update is called once per frame
    void Update()
    {
        pickUpInRange = Physics.CheckSphere(transform.position, 1, triggerLayer);

        if (pickUpInRange == true)
        {
            pickUpUI.SetActive(true);
            if (Input.GetMouseButton(0))
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<BoxCollider>().enabled = false;
                transform.position = pickUpLocation.transform.position;
                transform.SetParent(pickUpLocation.transform, true);
                //GetComponent<Transform>().localScale = new Vector3(2.5f, 1, 2.5f);

            }

            else
            {
                transform.SetParent(null);
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                transform.localScale = originalScale;
            }
        }

        else
        {
            pickUpUI.SetActive(false);
        }
    }




}


