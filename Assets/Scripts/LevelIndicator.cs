using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIndicator : MonoBehaviour
{
    static int level;

    private static Text myText;

    private void Start()
    {
        myText = GetComponent<Text>();
        setLevel(1);
    }

    public static void setLevel(int newLevel)
    {
        level = newLevel;

        myText.text = "Level " + level;
    }

}
