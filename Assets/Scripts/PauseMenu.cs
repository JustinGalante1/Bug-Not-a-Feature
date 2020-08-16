using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;

    private GameObject menu;
    private CameraController camControl;

    private void Start()
    {
        menu = GameObject.Find("Pause Menu");
        menu.SetActive(false);
        isPaused = false;

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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void levelSelect()
    {

    }

    public void quitGame()
    {

    }
}
