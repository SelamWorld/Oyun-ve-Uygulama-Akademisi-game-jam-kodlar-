using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void GotoSettingsMenu()
    {
        SceneManager.LoadScene("settingsMenu");
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("OpenMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

  
}
