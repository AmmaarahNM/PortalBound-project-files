using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    public PlayerMovement PM;
    public Transform start;
    public Transform end;
    public bool cubeOnPad;
    public Transform cube;
    public LayerMask padMask;

    public bool playerOnPad;
    public Transform pad;
    public LayerMask playerMask;

    public AudioSource movingSound;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = start.position;
    }

    // Update is called once per frame
    void Update()
    {
        cubeOnPad = Physics.CheckSphere(cube.position, 0.7f, padMask);
        playerOnPad = Physics.CheckSphere(pad.position, 0.9f, playerMask);

        if (playerOnPad == true || cubeOnPad == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, end.position, 2 * Time.deltaTime);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, start.position, 2 * Time.deltaTime);
        }

        if ((Vector3.Distance(transform.position, start.position) > 0.2) && (Vector3.Distance(transform.position, end.position) > 0.2))//(this.transform.position != start.position && this.transform.position != end.position)//((Vector3.Distance(this.transform.position, start.position) > 0.1) && (Vector3.Distance(this.transform.position, end.position) > 0.1))//
        {
            if (movingSound.isPlaying == false)
            {
                movingSound.Play();
                 
            }
          
        }

        else
        {
            
            movingSound.Stop();
        }


    }
}
