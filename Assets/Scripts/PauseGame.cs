using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool IsPaused { get; private set; }

    public GameObject pasueMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;

            if (IsPaused)
                Pause();
            else
                Resume();
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void Pause()
    {
        pasueMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pasueMenu.SetActive(false);
    }
}
