using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;

    private GameObject menu;
    private GameObject lsMenu;
    private CameraController camControl;

    private PlayerController pc;

    private DialogueManager dm;

    private void Start()
    {
        menu = GameObject.Find("Pause Menu");
        lsMenu = GameObject.Find("Select Level Menu");
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        dm = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();

        menu.SetActive(false);
        isPaused = false;

        lsMenu.SetActive(false);

        camControl = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        if (PlayerController.finished)
        {
            menu.SetActive(false);
            lsMenu.SetActive(true);
        }
        else
        {
            Dialogue levelSelectNotReady = new Dialogue();
            levelSelectNotReady.sentences = new string[1] { "Oops, that's not ready yet" };
            dm.startDialogue(levelSelectNotReady);
        }
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

    public void resetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
