using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject infoPanel;

    private void Start()
    {
        infoPanel.SetActive(false);
    }

    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void showInfo()
    {
        this.gameObject.SetActive(false);
        infoPanel.SetActive(true);

    }

    public void hideInfo()
    {
        this.gameObject.SetActive(true);
        infoPanel.SetActive(false);
    }
}
