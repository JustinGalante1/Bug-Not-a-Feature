using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    private GameObject player;
    private GameObject face;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        player = GameObject.FindGameObjectWithTag("Player");
        face = GameObject.Find("Face");
    }

    private void LateUpdate()
    {
        camControl();
    }

    private void camControl()
    {
        float rotationSpeed = 1;
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -90, 95);

        this.transform.position = player.transform.position + Vector3.up;
        this.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.transform.rotation = Quaternion.Euler(0, mouseX, 0);
        face.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }
}
