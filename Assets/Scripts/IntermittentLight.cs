using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermittentLight : MonoBehaviour
{
    public bool randomized;
    private Light myLight;
    private bool goingUp;

    private float amount;
    float minFlickerSpeed = 0.08f;
    float maxFlickerSpeed = 0.1f;

    public float speed;

    private void Start()
    {
        amount = .03f;
        myLight = this.GetComponent<Light>();
        goingUp = false;
    }

    void Update()
    {
        if (randomized)
        {
            amount = Random.Range(minFlickerSpeed, maxFlickerSpeed);
            if (Random.value >= 0.5f)
            {
                goingUp = true;
            }
            else
            {
                goingUp = false;
            }
        }

        if (goingUp)
        {
            if (myLight.range < 10)
            {
                myLight.range += amount * Time.deltaTime * speed;
            }
            else
            {
                goingUp = false;
            }
        }
        else
        {
            if(myLight.range > 3)
            {
                myLight.range -= amount * Time.deltaTime * speed;
            }
            else
            {
                goingUp = true;
            }
        }
    }
}
