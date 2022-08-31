using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10;
    public float gravity = -12;

    Vector3 velocity;

    public Transform groundCheck;
    public Transform triggerCheck;
    public float groundRad = 0.3f;
    public LayerMask groundMask;
    public LayerMask padMask;
    public LayerMask enemyMask;
    public LayerMask crystalMask;
    public bool isGrounded;
    public bool onPad;
    public bool enemyContact;
    public bool crystalSeen;
    public GameObject crystalUI;
    public GameManager GM;
    public GameObject injured;

    public float jumpHeight = 3;

    public Vector3 resetPosition;


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRad, groundMask);
        onPad = Physics.CheckSphere(groundCheck.position, groundRad, padMask);
        enemyContact = Physics.CheckSphere(transform.position, 1, enemyMask);
        crystalSeen = Physics.CheckSphere(triggerCheck.position, 0.5f, crystalMask);

        if (crystalSeen == true)
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 4, crystalMask))
            {
                crystalUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Destroy(hit.collider.gameObject);
                    //hit.collider.gameObject.SetActive(false);

                    GM.CrystalObtained();
                }
                
            }
            
            

            
        }
        else
        {
            crystalUI.SetActive(false);
        }


        if (isGrounded == true && velocity.y < 0)
        {
            velocity.y = -1;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        //use transform.right and forward instead of new vector3(x, 0, z) 
        //because the latter uses global coordinates while the former bases it off local position ie the direction the attached object is facing

        controller.Move(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); //from v = square root of -2hg
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (enemyContact == true)
        {
            controller.enabled = false;
            controller.transform.position = resetPosition;
            controller.transform.eulerAngles = Vector3.zero;
            controller.enabled = true;
            injured.SetActive(true);
            GM.HealthLoss();
            if (GM.health > 0)
            {
                StartCoroutine("DeactivateInjury");
            }
            
        }
        //controller.tag = "Player";
    }

    private IEnumerator DeactivateInjury()
    {
        yield return new WaitForSeconds(1);
        injured.SetActive(false); //MAKE IT FADE OUT INSTEAD
    }

}
