using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public SceneFader sceneFader;
    public string nextScene;
    
    public void QuitGame() {

        // Quits the application
        Application.Quit();
        Debug.Log("Game is exiting"); // This is for testing in the editor since Application.Quit doesn't work in the editor

    }

    public void StartGame() 
    {
        // Calls the fade function to transition into the lobby
        sceneFader.FadeToScene(nextScene);

    }
}