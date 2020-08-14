using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float v;
    private float h;

    [SerializeField]
    private float moveSpeed;

    private float jumpHeight = 750;
    private float GravityStrength = -50;
    private bool isGrounded;
    private Vector3 lastPosition;

    private Rigidbody rb;
    private TransitionController tc;

    private int curLevel;

    // Start is called before the first frame update
    void Start()
    {
        h = 0;
        v = 0;

        isGrounded = true;

        rb = this.GetComponent<Rigidbody>();
        tc = GameObject.Find("TransitionController").GetComponent<TransitionController>();

        curLevel = 1;

        Vector3 gravityS = new Vector3(0, GravityStrength, 0);
        Physics.gravity = gravityS;
    }

    // Update is called once per frame
    void Update()
    {
        getWASD();
        if(rb.velocity.y == 0)
        {
            lastPosition = this.rb.transform.position;
        }
        jump();
    }

    private void FixedUpdate()
    {
        playerMovement(h, v);
    }

    private void getWASD()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    private void playerMovement(float h, float v)
    {
        Vector3 moveX = rb.transform.right * h;
        Vector3 moveZ = rb.transform.forward * v;
        Vector3 movement = moveX + moveZ;
        movement.y = 0;
        movement = movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + movement);

        if(rb.transform.position.y < -15)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            if (curLevel <= 3)
            {
                rb.transform.position = new Vector3(rb.transform.position.x, 3, rb.transform.position.z);
            }
            else
            {
                rb.transform.position = lastPosition;   
            }
            
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(curLevel == 1)
            {
                rb.AddForce(Vector3.up * jumpHeight);
            }
            else if(curLevel == 2)
            {
                if (isGrounded)
                {
                    rb.AddForce(Vector3.up * jumpHeight);
                    isGrounded = false;
                }
            }
            else if(curLevel >= 3)
            {
                print("hi");
                if (isGrounded)
                {
                    rb.AddForce(Vector3.up * jumpHeight);
                    isGrounded = false;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(curLevel >= 3)
        {
            if (collision.collider.CompareTag("Floor")){
                isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(curLevel == 2)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (curLevel == 2)
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "Transition 1 to 2")
        {
            curLevel = 2;
        }

        if(collider.name == "Transition 2 to 3")
        {
            curLevel = 3;
        }

        if(collider.name == "Transition 3 to 4")
        {
            curLevel = 4;
        }

        if(collider.name == "Transition 4 to 5")
        {
            curLevel = 5;
        }
    }
}
