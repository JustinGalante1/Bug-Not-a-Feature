using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermittentLight : MonoBehaviour
{
    private Light myLight;
    private bool goingUp;

    private void Start()
    {
        myLight = this.GetComponent<Light>();
        goingUp = false;
    }

    void Update()
    {
        if (goingUp)
        {
            if (myLight.range < 10)
            {
                myLight.range += .03f;
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
                myLight.range -= .03f;
            }
            else
            {
                goingUp = true;
            }
        }
    }
}
