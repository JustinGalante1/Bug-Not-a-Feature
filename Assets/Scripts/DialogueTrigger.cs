using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private DialogueManager dm;

    private void Start()
    {
        dm = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
    }

    public void triggerDialogue()
    {
        dm.endDialogue();
        dm.startDialogue(dialogue);
    }
}
