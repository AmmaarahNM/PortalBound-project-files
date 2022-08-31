using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalonMovement : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed = 1.5f;
    public bool isMovingToEnd = true;
    float yRotation;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = start.position;
        //anim = GetComponent<Animator>();
        yRotation = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != start.position && transform.position != end.position)
        {
            anim.SetBool("Walk Forward", true);
        }

        if (Vector3.Distance(transform.position, start.position) < 0.1)
        {
            isMovingToEnd = true;

        }

        if (Vector3.Distance(transform.position, end.position) < 0.1)
        {
            isMovingToEnd = false;
        }

        if (isMovingToEnd == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, end.position, speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, yRotation, 0);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, start.position, speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, yRotation + 180, 0);
        }

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision");
            if (isMovingToEnd)
            {
                isMovingToEnd = false;
            }

            else
            {
                isMovingToEnd = true;
            }
        }
    }*/
}
