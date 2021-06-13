using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;

    public void Resume()
    {
        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //GameIsPaused = false;
    }
    public void Pause()
    {
        pauseButton.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //GameIsPaused = true;
    }
}
