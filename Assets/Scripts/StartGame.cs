using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadGame()
    {
        Debug.Log("SceneLoaded");
        SceneManager.LoadScene("GameScene");
    }
}
