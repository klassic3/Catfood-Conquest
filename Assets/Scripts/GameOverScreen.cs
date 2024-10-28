using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Method to restart the current scene
    public void RestartScene()
    {
        // Get the name of the current active scene
        string GameOverScene = SceneManager.GetActiveScene().name;
        // Reload the current scene
        SceneManager.LoadScene("GameOverScene");
    }

    // Method to load the main menu scene
    public void LoadMainMenu(string TitleScene)
    {
        // Load the main menu scene
        SceneManager.LoadScene(TitleScene);
    }
}

