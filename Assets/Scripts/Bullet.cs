using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject plasticParticle;
    public GameObject glassParticle;
    public GameObject bioParticle;
    public GameObject paperParticle;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float hitRange = 0.5f;

    private IEnumerator Attack(Enemy enemy, Tower tower, float damage)
    { 
        while (enemy.transform != null && Vector2.Distance(transform.position, enemy.transform.position) > hitRange)
        {
            Vector2 movingDirection = new Vector2(enemy.transform.position.x - transform.position.x, enemy.transform.position.y - transform.position.y).normalized;
            Vector2 newPosition = movingDirection * speed * Time.deltaTime;
            transform.position += new Vector3(newPosition.x, newPosition.y, 0f);
            yield return null;
        }

        if (enemy != null)
			enemy.AddDamage(damage, tower);

        CreateHitParticle(enemy);
        Destroy(gameObject);
    }

    public void StartAttack(Enemy enemy, Tower tower, float damage)
    {
        StartCoroutine(Attack(enemy, tower, damage));
    }

    private void CreateHitParticle(Enemy enemy)
    {
        GameObject particlePrefab = null;

        if (enemy.Type.HasFlag(EnemyType.Glass))
            particlePrefab = glassParticle;
        else if (enemy.Type.HasFlag(EnemyType.Organic))
            particlePrefab = bioParticle;
        else if (enemy.Type.HasFlag(EnemyType.Paper))
            particlePrefab = paperParticle;
        else if (enemy.Type.HasFlag(EnemyType.Plastic))
            particlePrefab = plasticParticle;

        if (particlePrefab != null)
        {
            var particleInstance = Instantiate(particlePrefab, enemy.transform.position, Quaternion.identity);
            Destroy(particleInstance, 5f);
        }
    }
}
