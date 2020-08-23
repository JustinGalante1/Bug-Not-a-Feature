using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float panAmount;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, panAmount * Time.deltaTime, 0, Space.World);
    }
}
