using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPCounter : MonoBehaviour
{
    public TMP_Text counter;
    private void Update()
    {
        counter.text = GameManager.Instance.baseHitPoints.ToString();
    }
}
