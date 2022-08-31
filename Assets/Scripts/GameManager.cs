using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Nwheel;
    public GameObject Swheel;
    public GameObject Wwheel;
    public GameObject Ewheel;


    public GameObject lockDoor;
    public bool doorOpen;
    public GameObject lockCrystal;
    bool gameOver;

    public int crystalsCollected;
    public int health = 4; 
    public GameObject[] healthIcon;
    public GameObject gameOverUI;
    public bool allCrystals;
    public GameObject[] crystalUIcheck;
    public PlayerMovement PM;
    public LookAround LA;
    public SceneChanger SC;
    bool paused;
    public GameObject pauseUI;

    public AudioSource crystalSound;
    public AudioSource injuredSound;
    public AudioSource backgroundSound;
    public AudioSource lockOpens;
    int soundPlayed;

    void Start()
    {
        gameOver = false;
        backgroundSound.Play();
    }

    // Update is called once per frame
    void Update()
    {


        if (Nwheel.transform.localEulerAngles == new Vector3 (0, 0, 72) && Swheel.transform.localEulerAngles == new Vector3(0, 0, 0) &&
            Wwheel.transform.localEulerAngles == new Vector3(0, 0, 252) && Ewheel.transform.localEulerAngles == new Vector3(0, 0, 324))
        {
           
            doorOpen = true;
            
            //delay lockdppr transform and put UI or audio to indicate success
            lockDoor.transform.eulerAngles = new Vector3(0, -15, 0);
            if (lockCrystal != null)
            {
                lockCrystal.SetActive(true);
                if (lockOpens.isPlaying == false && soundPlayed != 1)
                {
                    lockOpens.Play();
                    soundPlayed = 1;
                }

                
                
            }
            
        }

        if (crystalsCollected == 10)
        {
            allCrystals = true;
        }

        crystalUIcheck[crystalsCollected].SetActive(true);

        if (gameOver == true)
        {
            backgroundSound.Stop();
            //Debug.Log("GO");
            PM.enabled = false;
            LA.enabled = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {

                SC.ChangeScene(0);
                
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SC.ChangeScene(1);
            }
            //Cursor.visible = true;
            //deactivate movement? retry freezing time?
        }

        else
        {


            if (paused == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 0;
                    pauseUI.SetActive(true);
                    paused = true;
                }
            }

            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    SC.ChangeScene(0);
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Time.timeScale = 1;
                    pauseUI.SetActive(false);
                    paused = false;
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (LA.mouseSensitivity < 100)
                    {
                        LA.mouseSensitivity++;
                    }
                    
                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (LA.mouseSensitivity > 50)
                    {
                        LA.mouseSensitivity--;
                    }

                }
            }

        }
    }

    public void CrystalObtained()
    {
        crystalsCollected++;
        //Debug.Log(crystalsCollected + "/10");
        crystalSound.Play();
    }

    public void HealthLoss()
    {
        health--;
        healthIcon[health].SetActive(false);
        injuredSound.Play();
        
        if (health <= 0)
        {
            gameOver = true;
            
            gameOverUI.SetActive(true);
            
            
        }
    }
}
