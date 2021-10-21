using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pasueMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            pasueMenu.SetActive(true);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        pasueMenu.SetActive(false);
    }
}
