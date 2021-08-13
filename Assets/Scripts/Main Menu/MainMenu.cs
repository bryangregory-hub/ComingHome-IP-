/******************
 * Author: Nicholas Chen
 * Name Of class:Main Menu
 * Description of Class: This will control the button functions on the menu screens and the scene management
 * Date Created: 10/8/2021
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// The scene that would display according to what button the user selects
/// </summary>
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
