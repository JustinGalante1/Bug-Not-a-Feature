using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private static string lvl1Intro = "Welcome to the Universe. Good luck making that jump";
    private static string lvl1Hint = "Pretty unlucky you only have one jump, isn't it";
    private static string lvl1Close = "Forgot to check if you're touching the ground before you jump. Classic";

    private static string lvl2Intro = "What will you do now that you can't fly?";
    private static string lvl2Hint = "Can't believe I forgot about the classic jump bug back there. Hope I fixed it properly...";
    private static string lvl2Close = "bruh";

    private static string lvl3Intro = "Finally fixed jumping, but just in case, i'll stick you in a room with 4 padded walls to keep you in place";
    private static string lvl3Hint = "Don't worry, you won't die in here. Probably";
    private static string lvl3Close = "idek what to say";

    private static string lvl4Intro = "I'm not a bad coder, am I? I'm gettin tired of fixing all my mistakes...";
    private static string lvl4Hint = "Made sure to lock the box up real tight";
    private static string lvl4Close = "I'm actually not sure how to fix that";

    private static string lvl5Intro = "Two buttons, one box";
    private static string lvl5Hint = "good thing the box is too small to hit both buttons";
    private static string lvl5Close = "I've never even seen that before";

    private static string lvl6Intro = "here's a door you can't open";
    private static string lvl6Hint = "bulbs are too bright again";
    private static string lvl6Close = "I guess sweeping my problems under the table doesn't work in games either...";

    private static string lvl7Intro1 = "I'm tired of making levels, so here's the last one.";
    private static string lvl7Intro2 = "If you get super tilted, feel free to jump on the PURPLE button to go back to lvl 1. You were actually able to do something back then.";
    private static string lvl7Intro3 = "Also, I finally got the Level Select to work, so you should try that out if you feel nostalgic";
    private static string lvl7Hint1 = "hopefully the purple button and level select work how i think they do";
    private static string lvl7Hint2 = "feelin pretty nostalgic. I put so much effort into the purple button and the level select, try it out before you quit";
    private static string lvl7Close = "i give up. I don't know how to program a game. ty for that.";

    private static Text myText;

    private float hintDelay = 45;

    private void Start()
    {
        myText.text = lvl1Intro;
    }

    public static void setDialogue(string dialogue)
    {
        switch (dialogue)
        {
            case "lvl1Intro":
                myText.text = lvl1Intro;
                break;
            case "lvl1Hint":
                myText.text = lvl1Hint;
                break;
            case "lvl1Close":
                myText.text = lvl1Close;
                break;
            case "lvl2Intro":
                myText.text = lvl2Intro;
                break;
            case "lvl2Hint":
                myText.text = lvl2Hint;
                break;
            case "lvl2Close":
                myText.text = lvl2Close;
                break;
            case "lvl3Intro":
                myText.text = lvl3Intro;
                break;
            case "lvl3Hint":
                myText.text = lvl3Hint;
                break;
            case "lvl3Close":
                myText.text = lvl3Close;
                break;
            case "lvl4Intro":
                myText.text = lvl4Intro;
                break;
            case "lvl4Hint":
                myText.text = lvl4Hint;
                break;
            case "lvl4Close":
                myText.text = lvl4Close;
                break;
            case "lvl5Intro":
                myText.text = lvl5Intro;
                break;
            case "lvl5Hint":
                myText.text = lvl5Hint;
                break;
            case "lvl5Close":
                myText.text = lvl5Close;
                break;
            case "lvl6Intro":
                myText.text = lvl6Intro;
                break;
            case "lvl6Hint":
                myText.text = lvl6Hint;
                break;
            case "lvl6Close":
                myText.text = lvl6Close;
                break;
            case "lvl7Intro1":
                myText.text = lvl7Intro1;
                break;
            case "lvl7Intro2":
                myText.text = lvl7Intro2;
                break;
            case "lvl7Intro3":
                myText.text = lvl7Intro3;
                break;
            case "lvl7Hint1":
                myText.text = lvl7Hint1;
                break;
            case "lvl7Hint2":
                myText.text = lvl7Hint2;
                break;
            case "lvl7Close":
                myText.text = lvl7Close;
                break;
        }
    }

}
