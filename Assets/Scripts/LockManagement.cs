using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManagement : MonoBehaviour
{
    bool inFrontOfLock;
    public GameObject checkPt;
    public LayerMask triggerLayer;
    public bool lockInspection;
    public GameManager GM;
    public PlayerMovement PM;

    public GameObject inspectUI;
    public GameObject lockUI;


    // Update is called once per frame
    void Update()
    {
        inFrontOfLock = Physics.CheckSphere(checkPt.transform.position, 1, triggerLayer);
        if (GM.doorOpen == false)
        {
            if (inFrontOfLock == true)
            {
                if (lockInspection == false)
                {
                    inspectUI.SetActive(true);
                }
                

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (lockInspection == true)
                    {
                        inspectUI.SetActive(true);
                        lockUI.SetActive(false);
                        lockInspection = false;

                    }

                    else
                    {
                        inspectUI.SetActive(false);
                        lockUI.SetActive(true);
                        lockInspection = true;
                    }
                }
            }

            else
            {
                inspectUI.SetActive(false);
                lockUI.SetActive(false);
            }

            if (lockInspection == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                PM.controller.enabled = false;
            }

            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                PM.controller.enabled = true;
            }
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PM.controller.enabled = true;
            inspectUI.SetActive(false);
            lockUI.SetActive(false);
        }
        
    }
}
