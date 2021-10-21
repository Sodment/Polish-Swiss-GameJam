using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public Sprite deadBase;
    [SerializeField] private float rotationSpeed = 0.5f;
    public void Defeat(GameObject baseGO)
    {
        StartCoroutine(magicDeath(baseGO));
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
