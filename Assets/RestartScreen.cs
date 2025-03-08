using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScreen : MonoBehaviour
{
    public void playGame () {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void quitGame() {
        Application.Quit();
    }
}
