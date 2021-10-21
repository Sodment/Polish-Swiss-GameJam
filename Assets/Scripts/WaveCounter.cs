using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{
    public TMP_Text counter;
    void Update()
    {
        counter.text = GameManager.Instance.Spawner.WaveNumber.ToString();
    }
}
