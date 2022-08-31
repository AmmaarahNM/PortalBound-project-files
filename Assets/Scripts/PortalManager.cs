using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PortalManager : MonoBehaviour
{
    public bool contact;
    public LayerMask triggerLayer;
    public GameObject portal2D;
    public Material blueTones;
    public GameObject[] changeBlues;
    public Image blueFade;
    public Image fadeOut;


    public GameObject contactUI;
    public GameObject notEnoughUI;
    public GameObject poweringUpUI;
    bool Xpressed;

    public GameManager GM;
    public PlayerMovement PM;
    public GameObject preparationUI;
    public GameObject endUI;
    bool end;

    public AudioSource powerUpSound;
    public AudioSource powerDown;
    

    // Start is called before the first frame update
    void Start()
    {
        //PowerUpPortal(); //testing
        blueFade.canvasRenderer.SetAlpha(0);
        //FadeOut();
        fadeOut.canvasRenderer.SetAlpha(1);
        fadeOut.CrossFadeAlpha(0, 1.5f, false);
        end = false;

    }

    // Update is called once per frame
    void Update()
    {
        contact = Physics.CheckSphere(transform.position, 2.6f, triggerLayer);

        if (contact == true)
        {
            contactUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                Xpressed = true;
                

                if (GM.allCrystals == false)
                {
                    notEnoughUI.SetActive(true);
                }

                else
                {
                    PowerUpPortal();
                    //powerUp function called
                }
            }
            
        }

        else
        {
            Xpressed = false;
            contactUI.SetActive(false);
            notEnoughUI.SetActive(false);
        }

        if (Xpressed == true)
        {
            contactUI.SetActive(false);
        }

        if (end == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            contactUI.SetActive(false);
        }
    }

    public void PowerUpPortal()
    {
        poweringUpUI.SetActive(true);
        powerUpSound.Play();
        StartCoroutine(PowerUpLights(1));
        StartCoroutine(PowerUpLights(2));
        StartCoroutine(PowerUpLights(3));
        StartCoroutine(PowerUpLights(4));
        StartCoroutine(PowerUpLights(5));
        StartCoroutine(PowerUpLights(6));
        StartCoroutine(PowerUpLights(7));
        StartCoroutine(EndSequence());
        StartCoroutine(EndUI());

        //activate portal light and collider
        //replace pu UI with prepare for lighttravel
        //deactivate char and move player back to see it all
    }

    private IEnumerator PowerUpLights(int index)
    {
        yield return new WaitForSeconds(index);
        Renderer blueRend = changeBlues[index - 1].GetComponent<Renderer>();
        blueRend.material = blueTones;

        if (index == 7)
        {
            portal2D.SetActive(true); //Fade in!!!
            powerDown.Play();
            poweringUpUI.SetActive(false);
            //PM.controller.enabled = false;
            PM.enabled = false;
            end = true;
            preparationUI.SetActive(true);
           
        }
    }

    private IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(8);
        FadeOut();
               
    }

    private IEnumerator EndUI()
    {
        yield return new WaitForSeconds(10.5f);

        endUI.SetActive(true);
        
    }

    void FadeOut()
    {
        blueFade.CrossFadeAlpha(1, 3, false);
    }


}
