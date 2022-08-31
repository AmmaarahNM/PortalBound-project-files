using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCheck : MonoBehaviour
{
    public bool crystalSeen;
    public GameObject crystalUI;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (crystalSeen == true)
        {
            crystalUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                GM.CrystalObtained();
            }


        }
        else
        {
            crystalUI.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "crystal")
        {
            crystalSeen = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "crystal")
        {
            crystalSeen = false;
        }
    }
}
