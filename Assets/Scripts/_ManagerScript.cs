using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class _ManagerScript : MonoBehaviour {

    // quit from the game
	public void Quit()
    {
        Application.Quit();
    }

    // start the game
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        // SceneManager.LoadSceneAsync("TestScene");
    }

    public void InGameOptions()
    {
        SceneManager.LoadScene("Options");
    }

    // go the rules of the game page
    public void GameInstructions()
    {
        SceneManager.LoadScene("Rules");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
