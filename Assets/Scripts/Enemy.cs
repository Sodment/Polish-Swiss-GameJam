using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string _name;

    [Space]
    [SerializeField] private EnemyType _type;
    [SerializeField] private float _value = 5;

    

    [Space]
    [SerializeField] private float _health;

    public bool AddDamage(float damage)
    {
        var newHealth = _health - damage;
        _health = newHealth;

        return newHealth <= 0;

    }
}
