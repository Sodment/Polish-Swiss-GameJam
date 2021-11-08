using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    public static SoundSource Instance { get; private set; }

    public bool DontDestroyOnSceneChange = true;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (DontDestroyOnSceneChange)
            DontDestroyOnLoad(gameObject);
    }
}
