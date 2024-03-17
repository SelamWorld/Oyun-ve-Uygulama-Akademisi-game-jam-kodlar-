using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public void pauseMenu()
    {
        SceneManager.LoadScene("pauseMenu");
    }

    public GameObject pauseMenuPanel;

    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackMainMenu()
    {
        pauseMenuPanel.SetActive(false);
        SceneManager.LoadScene("OpenMenu");
    }

}


  

