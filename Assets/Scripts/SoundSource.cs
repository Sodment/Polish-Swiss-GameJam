using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    public bool DontDestroyOnSceneChange = true;

    private void Start()
    {
        if (DontDestroyOnSceneChange)
            DontDestroyOnLoad(gameObject);
    }
}
