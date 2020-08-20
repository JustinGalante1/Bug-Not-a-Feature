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
    public bool reset = false;

    private Light myLight;

    private bool changed;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        myRenderer = this.GetComponent<Renderer>();
        myLight = this.GetComponentInChildren<Light>();

        myLight.intensity = 0;

        mat = myRenderer.material;

        notHighlighted = mat.GetColor("_EmissionColor");

        changed = false;

        playerHand = GameObject.Find("Hand").transform;

        spawnPosition = this.transform.position;
        spawnRotation = this.transform.rotation;
        spawnScale = this.transform.localScale;
    }

    private void Update()
    {
        if(rb.transform.position.y < -3)
        {
            resetPosition(false);
            reset = false;
        }
        if (beingHeld && !reset)
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
        if (!beingHeld && !changed)
        {
            myLight.intensity = 2;
            changed = true;
            mat.SetColor("_EmissionColor", notHighlighted * 8);
        }
    }

    private void OnMouseExit()
    {
        if (!beingHeld)
        {
            myLight.intensity = 0;
            changed = false;
            mat.SetColor("_EmissionColor", mat.GetColor("_EmissionColor")/8);
        }
    }

    public void resetPosition(bool fixScale)
    {
        reset = true;
        this.transform.parent = null;
        beingHeld = false;
        rb.transform.position = spawnPosition;
        rb.transform.rotation = spawnRotation;
        if (fixScale)
        {
            rb.transform.localScale = spawnScale;
        }
        mat.color = notHighlighted;
    }
}
