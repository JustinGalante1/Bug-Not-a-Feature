using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool used;

    private IndividualDialogue id;

    public bool active;

    private void Start()
    {
        id = this.GetComponent<IndividualDialogue>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && used == false)
        {
            id.triggerDialogue();
            used = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && used == false && active)
        {
            id.triggerDialogue();
            used = true;
        }
    }
}
