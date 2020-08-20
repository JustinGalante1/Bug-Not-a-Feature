using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    private bool used;

    private DialogueTrigger dt;

    private void Start()
    {
        dt = this.GetComponent<DialogueTrigger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && used == false)
        {
            dt.triggerDialogue();
            used = true;
        }
    }
}
