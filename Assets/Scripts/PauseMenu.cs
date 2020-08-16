using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;

    private GameObject menu;
    private GameObject lsMenu;
    private CameraController camControl;

    private PlayerController pc;

    private void Start()
    {
        menu = GameObject.Find("Pause Menu");
        lsMenu = GameObject.Find("Select Level Menu");
        pc = GameObject.Find("Player").GetComponent<PlayerController>();

        menu.SetActive(false);
        isPaused = false;

        lsMenu.SetActive(false);

        camControl = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused == true)
            {   
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        menu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        menu.SetActive(false);
        lsMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void openlevelSelect()
    {
        menu.SetActive(false);
        lsMenu.SetActive(true);
    }

    public void closeLevelSelect()
    {
        menu.SetActive(true);
        lsMenu.SetActive(false);
    }

    public void chooseLevel(string levelNum)
    {
        pc.levelUpdater(Int16.Parse(levelNum));
        Resume();
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
