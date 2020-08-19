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
    private Camera cam;
    private GameObject playerCenter;

    private Vector3 normalScale;
    private Vector3 halfScale;

    private int curLevel;
    private bool scaled;

    private Pickup level4Box;
    private Pickup level5Box;
    private GameObject hiddenWall1;
    private GameObject hiddenWall2;

    public static bool finished = false;

    // Start is called before the first frame update
    void Start()
    { 
        h = 0;
        v = 0;

        isGrounded = true;

        rb = this.GetComponent<Rigidbody>();
        cam = Camera.main.GetComponent<Camera>();
        playerCenter = GameObject.Find("PlayerStart");

        normalScale = this.transform.localScale;
        halfScale = normalScale - new Vector3(0.5f, 0, 0.5f);

        Vector3 gravityS = new Vector3(0, GravityStrength, 0);
        Physics.gravity = gravityS;

        scaled = false;
        finished = false;

        level4Box = GameObject.Find("Level 4 Box").GetComponent<Pickup>();
        level5Box = GameObject.Find("Level 5 Box").GetComponent<Pickup>();

        hiddenWall1 = GameObject.Find("Hidden Wall1");
        hiddenWall2 = GameObject.Find("Hidden Wall2");

        levelUpdater(1);
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
                print("hi");
                rb.AddForce(Vector3.up * jumpHeight);
            }
            else if(curLevel >= 2)
            {
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
        if (curLevel == 2)
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
        if (!finished)
        {
            if (collider.name == "Transition 1 to 2")
            {
                levelUpdater(2);
            }

            if (collider.name == "Transition 2 to 3")
            {
                levelUpdater(3);
            }

            if (collider.name == "Transition 3 to 4")
            {
                levelUpdater(4);
            }

            if (collider.name == "Transition 4 to 5")
            {
                level4Box.resetPosition();
                level4Box.reset = false;
                levelUpdater(5);
            }
            if (collider.name == "Transition 5 to 6")
            {
                level5Box.resetPosition();
                level5Box.reset = false;
                levelUpdater(6);
            }
            if (collider.name == "Transition 6 to 7")
            {
                levelUpdater(7);
            }
        }
    }

    public int getLevel()
    {
        return this.curLevel;
    }

    public void levelUpdater(int level)
    {
        print("updating level to " + level);
        if(level == 1)
        {
            curLevel = 1;
            cam.nearClipPlane = 0.1f;
            this.transform.localScale = normalScale;
            hiddenWall1.SetActive(true);
            hiddenWall2.SetActive(true);
        }

        else if(level == 2)
        {
            curLevel = 2;
            cam.nearClipPlane = 0.1f;
            this.transform.localScale = normalScale;
            hiddenWall1.SetActive(true);
            hiddenWall2.SetActive(true);
        }

        else if(level == 3)
        {
            curLevel = 3;
            cam.nearClipPlane = 0.1f;
            this.transform.localScale = normalScale;
            hiddenWall1.SetActive(false);
            hiddenWall2.SetActive(false);
        }

        else if(level == 4)
        {
            curLevel = 4;
            cam.nearClipPlane = 0.1f;
            this.transform.localScale = normalScale;
            hiddenWall1.SetActive(true);
            hiddenWall2.SetActive(true);
        }

        else if(level == 5)
        {
            curLevel = 5;
            cam.nearClipPlane = 0.1f;
            this.transform.localScale = halfScale;
            hiddenWall1.SetActive(true);
            hiddenWall2.SetActive(true);
        }

        else if(level == 6)
        {
            curLevel = 6;
            cam.nearClipPlane = 0.6f;
            this.transform.localScale = normalScale;
            hiddenWall1.SetActive(true);
            hiddenWall2.SetActive(true);
        }

        else if(level == 7)
        {
            curLevel = 7;
            cam.nearClipPlane = 0.1f;
            this.transform.localScale = normalScale;
            hiddenWall1.SetActive(true);
            hiddenWall2.SetActive(true);
            finished = true;
        }
    }
}
