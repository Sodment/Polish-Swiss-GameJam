using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    public static GameManager Instance { get; private set; }

    public Spawner Spawner => _spawner;

    private void Awake()
    {
        Instance = this;
    }


}
