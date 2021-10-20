using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float hitRange = 0.5f;
    private IEnumerator coroutine;
    private IEnumerator Attack(Enemy enemy, float damage)
    {
        while(Vector2.Distance(transform.position, enemy.transform.position) > hitRange)
        {
            Vector2 movingDirection = new Vector2(enemy.transform.position.x - transform.position.x, enemy.transform.position.y - transform.position.y).normalized;
            Vector2 newPosition = movingDirection * speed * Time.deltaTime ;
            transform.position += new Vector3(newPosition.x, newPosition.y, 0f);
            yield return null;
        }
        
        enemy.AddDamage(damage);
        Destroy(gameObject);
        yield return null;
    }
    public void StartAttack(Enemy enemy, float damage)
    {
        coroutine = Attack(enemy, damage);
        StartCoroutine(coroutine);
    }
}
