using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer myRenderer;
    private Material mat;

    private Color notHighlighted;
    private Color highLighted;

    private Transform playerHand;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    private Vector3 spawnScale;

    private bool beingHeld = false;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        myRenderer = this.GetComponent<Renderer>();
        mat = myRenderer.material;

        notHighlighted = mat.color;
        highLighted = notHighlighted + new Color(10, 0, 0);

        playerHand = GameObject.Find("Hand").transform;

        spawnPosition = this.transform.position;
        spawnRotation = this.transform.rotation;
        spawnScale = this.transform.localScale;
    }

    private void Update()
    {
        if(rb.transform.position.y < -3)
        {
            rb.transform.position = spawnPosition;
            rb.transform.rotation = spawnRotation;
            rb.transform.localScale = spawnScale;
            mat.color = notHighlighted;
        }
        if (beingHeld)
        {   
            rb.transform.position = playerHand.transform.position;
        }
    }

    private void OnMouseDown()
    {
        rb.mass = 0f;
        beingHeld = true;
        rb.useGravity = false;
        rb.drag = 1000;
        rb.angularDrag = 1000;
        this.transform.parent = playerHand;
    }

    private void OnMouseUp()
    {
        rb.mass = 5f;
        beingHeld = false;
        rb.useGravity = true;
        rb.drag = 1;
        rb.angularDrag = 0.05f;
        this.transform.parent = null;
    }

    private void OnMouseOver()
    {
        if (!beingHeld)
        {
            mat.color = highLighted;
        }
    }

    private void OnMouseExit()
    {
        if (!beingHeld)
        {
            mat.color = notHighlighted;
        }
    }
}
