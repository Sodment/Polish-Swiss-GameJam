using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string _name;

    [Space]
    [SerializeField] private EnemyType _type;
    [SerializeField] private float _value = 5;
    public void DealDamage(float damage)
    {
        Debug.Log("I got hit for " + damage + " damage");
    }
    public float givemedist()
    {
        return 1f;
    }
}
