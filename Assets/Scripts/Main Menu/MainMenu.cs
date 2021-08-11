using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playgame()
    {
        //changes to title scene
        SceneManager.LoadScene("Demo");
    }
    public void QuitGame()
    {//quits games
        Debug.Log("quit");
        Application.Quit();
    }
}
