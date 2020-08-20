using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    Dialogue initialDialogue;

    private Text myText;

    private Queue<string> sentences;

    private float hintDelay = 45;

    private void Start()
    {
        myText = GameObject.Find("ChatBox").GetComponent<Text>();

        initialDialogue = new Dialogue();
        initialDialogue.sentences = new string[2]{"Welcome to the Universe. Good luck making that jump", "Pretty unlucky you only have one jump, isn't it"};
        initialDialogue.lvlName = "level1";

        sentences = new Queue<string>();

        startDialogue(initialDialogue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            displayNextSentence();
        }
    }

    public void startDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue for " + dialogue.lvlName);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        displayNextSentence();
        StartCoroutine(WaitForHint());
    }

    private void displayNextSentence()
    {
        if(sentences.Count == 0)
        {
            endDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentence)
    {
        myText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            myText.text += letter;
            yield return null;
        }
    }

    IEnumerator WaitForHint()
    {
        while(sentences.Count != 0)
        {
            yield return new WaitForSeconds(45);
            displayNextSentence();
        }
    }

    public void endDialogue()
    {
        StopAllCoroutines();
        Debug.Log("Dialogue ended");
    }

}
