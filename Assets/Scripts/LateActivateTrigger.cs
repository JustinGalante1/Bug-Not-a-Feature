using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateActivateTrigger : MonoBehaviour
{
    LateActivate la;
    private bool done;

    private void Start()
    {
        done = false;
        la = this.GetComponent<LateActivate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && done == false)
        {
            la.startTimer();
        }
    }
}
