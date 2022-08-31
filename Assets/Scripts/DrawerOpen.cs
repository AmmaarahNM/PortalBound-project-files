using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerOpen : MonoBehaviour
{
    bool unlocked;
    bool tableRange;
    bool keyRange;
    public LayerMask triggerLayer;
    public GameObject tableCheck;
    public GameObject keyObj;
    public GameObject drawer;
    public Transform start;
    public Transform end;
    public GameObject hiddenCrystal;
    

    public Text tableUI;
    public bool key;
    //public GameObject noKey;
    bool Epressed;
    public GameObject keyUI;
    public GameObject keyKeptUI;

    public Vector3 tablePos;
    public Vector3 tableRot;
    public PlayerMovement PM;

    public AudioSource drawerUnlocked;
    int soundPlayed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tableRange = Physics.CheckSphere(tableCheck.transform.position, 1, triggerLayer);
        keyRange = Physics.CheckSphere(keyObj.transform.position, 2, triggerLayer);

        if (keyRange == true && key == false)
        {
            keyUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                keyObj.SetActive(false);
                keyKeptUI.SetActive(true);
                key = true;
                
            }
        }

        else
        {
            keyUI.SetActive(false);
        }

        if (tableRange == true && unlocked == false)
        {
            tableUI.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Epressed = true;
                if (key == true)
                {
                    tableUI.enabled = false;
                    unlocked = true;
                    if (drawerUnlocked.isPlaying == false && soundPlayed != 1)
                    {
                        drawerUnlocked.Play();
                        soundPlayed = 1;
                    }


                    PM.controller.enabled = false;
                    PM.controller.transform.position = tablePos;
                    PM.controller.transform.eulerAngles = tableRot;
                    PM.controller.enabled = true;
                }

            }
        }

        else
        {
            Epressed = false;
            tableUI.enabled = false;

        }

        if (unlocked == true)
        {
            keyKeptUI.SetActive(false);
            if (hiddenCrystal != null)
            {
                hiddenCrystal.SetActive(true);
            }
            
            drawer.transform.position = Vector3.MoveTowards(drawer.transform.position, end.position, 2 * Time.deltaTime);
        }

        else
        {
            drawer.transform.position = Vector3.MoveTowards(drawer.transform.position, start.position, 2 * Time.deltaTime);
        }

        if (Epressed == true)
        {
            tableUI.text = "Drawer locked!";
        }

        else
        {
            tableUI.text = "Open drawer (E)";
        }
    }




}
