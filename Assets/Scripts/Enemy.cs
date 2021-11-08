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

    private LevelManager _level;

    public EnemyType Type => _type;

    public float Value => _value;

    public float Health => _health;

    public bool IsDead => _health <= 0f;

    private void Start()
    {
        _level = FindObjectOfType<LevelManager>();
    }

    public bool AddDamage(float damage, Tower source)
    {
        var newHealth = Mathf.Max(0f, _health - damage);
        _health = newHealth;
        if(_health == 0)
        {
            GetKilled(source);
        }
        return newHealth <= 0f;
    }

    public void GetKilled(Tower source)
    {
        GameManager.Instance.money += Value * source.moneyGain;
        _level.notificater.MakeNotificationMoney(transform.position, Value * source.moneyGain);
        Die(source.transform);
    }

    public void Die(Transform source)
    {
        TrashMovement movement = gameObject.GetComponent<TrashMovement>();
        movement.stopMovement();
        movement.lastMovement(source.transform);
    }
}
