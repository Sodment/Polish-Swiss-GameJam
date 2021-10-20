using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float hitRange = 0.5f;
    private IEnumerator coroutine;
    private IEnumerator Attack(Enemy enemy, Tower tower, float damage)
    {
        enemy.AddDamage(damage);
        while (Vector2.Distance(transform.position, tower.transform.position) > hitRange)
        {
            Vector2 movingDirection = new Vector2(tower.transform.position.x - transform.position.x, tower.transform.position.y - transform.position.y).normalized;
            Vector2 newPosition = movingDirection * speed * Time.deltaTime ;
            transform.position += new Vector3(newPosition.x, newPosition.y, 0f);
            yield return null;
        }
        
        
        Destroy(gameObject);
        yield return null;
    }
    public void StartAttack(Enemy enemy,Tower tower, float damage)
    {
        coroutine = Attack(enemy, tower, damage);
        StartCoroutine(coroutine);
    }
}
