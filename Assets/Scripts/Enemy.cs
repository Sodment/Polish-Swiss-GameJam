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

    public EnemyType Type => _type;

    public float Value => _value;

    public float Health => _health;

    public bool IsDead => _health <= 0f;

    public bool AddDamage(float damage, Tower source)
    {
        var newHealth = Mathf.Max(0f, _health - damage);
        _health = newHealth;
        
        return newHealth <= 0f;
    }
    public void Die()
    {
        gameObject.GetComponent<TrashMovement>().stopMovement();
        GameManager.Instance.money += Value;
        Debug.Log("Dead: " + name + " money: " + GameManager.Instance.money);
    }
    
}
