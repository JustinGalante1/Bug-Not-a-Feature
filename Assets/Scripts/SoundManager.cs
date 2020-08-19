using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static AudioClip transition;

    static AudioSource audioSrc;

    private void Start()
    {
        transition = Resources.Load<AudioClip>("Sounds/transition");

        audioSrc = this.GetComponent<AudioSource>();    
    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "transition":
                audioSrc.PlayOneShot(transition);
                break;
        }
    }
}
