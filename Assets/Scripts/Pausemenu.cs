using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject pauseMenuUI;
    public GameObject mapCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Paused)
            {
                MapOff();
            }
            else
            {
                MapOn();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void MapOn()
    {
        mapCamera.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void MapOff()
    {
        mapCamera.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
}
