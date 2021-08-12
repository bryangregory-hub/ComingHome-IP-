using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playgame()
    {
        //changes to title scene
        SceneManager.LoadScene("SampleScene");
    }

    public void backtomenu()
    {
        //changes the scene to the title screen
        SceneManager.LoadScene("MainMenuScreen");
    }

    public void deathscreen()
    {
        //changes to death screen scene
        SceneManager.LoadScene("DeathMenu");
    }

    public void QuitGame()
    {
        //closes the game
        Debug.Log("quit");
        Application.Quit();
    }
}
