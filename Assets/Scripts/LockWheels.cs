using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockWheels : MonoBehaviour
{
    public LockManagement LM;
    public LayerMask wheelLayer;
    Vector3 initialRotation;
    public int rotateCounter;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.eulerAngles.z == -360)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }*/

        if (rotateCounter == 10)
        {
            transform.eulerAngles = initialRotation;
            rotateCounter = 0;
        }

        if (Input.GetMouseButtonDown(0))  //THEY ALL CHANGE AT ONCE FOR THIS!
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 4, wheelLayer))
            {
                if (hit.transform == this.transform && LM.lockInspection == true)
                {
                    
                    this.transform.eulerAngles += new Vector3(0, 0, -36);
                    rotateCounter++;
                    Debug.Log(this.transform.name + this.transform.eulerAngles);
                }
            }

        }
    }

    private void OnMouseDown()
    {
        Debug.Log("clicked");
        if (LM.lockInspection == true)
        {
            transform.eulerAngles += new Vector3(0, 0, -36);
        }
    }
}
