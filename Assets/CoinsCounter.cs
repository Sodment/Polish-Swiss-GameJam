using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinsCounter : MonoBehaviour
{
    public TMP_Text counter;
    void Update()
    {
        counter.text = GameManager.Instance.money.ToString();
    }
}
