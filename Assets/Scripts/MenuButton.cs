using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Text mytext;

    private Color normal;
    private Color highlighted;

    private void Start()
    {
        normal = new Color(255, 255, 255);
        highlighted = new Color(230, 230, 230);
    }

    private void OnMouseOver()
    {
        mytext.color = highlighted;
    }

    private void OnMouseExit()
    {
        mytext.color = normal;
    }
}
