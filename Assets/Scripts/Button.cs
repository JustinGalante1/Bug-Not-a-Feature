using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;

    private Vector3 doorPos;

    private float count = 0;

    public float raiseAmount = 0;

    private bool opened = false;

    private void Start()
    {
        doorPos = door.transform.position;
    }

    private void Update()
    {
        if(opened == false)
        {
            if(count > 0)
            {
                opened = true;
                door.transform.position += new Vector3(0, raiseAmount, 0);
            }
        }
        else
        {
            if(count <= 0)
            {
                opened = false;
                door.transform.position -= new Vector3(0, raiseAmount, 0);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pickup") || collision.collider.CompareTag("Player"))
        {
            count++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Pickup") || collision.collider.CompareTag("Player"))
        {
            count--;
        }
    }
}
