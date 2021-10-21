using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public Notificater notificater;
    public Sprite deadBase;
    [SerializeField] private float rotationSpeed = 0.5f;

    public void Defeat(GameObject baseGO)
    {
        StartCoroutine(magicDeath(baseGO));
        SceneManager.LoadScene("Level2");

    }
    private IEnumerator magicDeath(GameObject baseGO)
    {
        while(baseGO.transform.rotation.eulerAngles.y < 90f)
        {
            baseGO.transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
            yield return null;
        }
        
        baseGO.GetComponent<SpriteRenderer>().sprite = deadBase;
        while (baseGO.transform.rotation.eulerAngles.y < 180f)
        {
            baseGO.transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
            yield return null;
        }
    }
}
