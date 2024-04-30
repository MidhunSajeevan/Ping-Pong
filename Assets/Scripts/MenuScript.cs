using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Loads the next scene in the build order
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quits the application
    public void ExitGame()
    {
        Application.Quit();
    }

    // Restarts the game by loading a specific scene (assuming it's a restart scene)
    public void RestartGame()
    {
        // Replace the scene index (1) with the actual restart scene index in your build settings
        SceneManager.LoadScene(1);
    }
}
