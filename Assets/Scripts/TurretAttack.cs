using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    public Tower tower;
    public GameObject bulletPrefab;
    public Spawner spawner;
    private float lastAttackTime = 0f;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, tower.GetStats().AttackRange);
    }
    private void Update()
    {
        TryShoot();
    }
    private void TryShoot()
    {
        Tower.TowerAttackInfo stats = tower.GetStats();
        if(lastAttackTime + stats.AttackFrequency < Time.time)
        {
            List<Enemy> enemiesInRange = GetEnemiesInRange(stats.AttackRange);
            if(enemiesInRange.Count > 0)
            {
                Enemy enemyToAttack = ChooseEnemyToAttack(enemiesInRange);
                Attack(enemyToAttack);
            }
        }
    }
    private List<Enemy> GetEnemiesInRange(float range)
    {
        List<Enemy> result = new List<Enemy>();
        List<Enemy> allEnemiesAlive = spawner.AliveEnemies;
        //List<Enemy> allEnemiesAlive = new List<Enemy>();
        //allEnemiesAlive.Add(GameObject.Find("PlasticTrash").GetComponent<Enemy>());
        foreach (Enemy candidate in allEnemiesAlive)
        {
            
            if (CanAttack(candidate) && InRange(candidate))
            {
                result.Add(candidate);
                
            }
        }
        return result;
    }
    private bool CanAttack(Enemy enemy)
    {
        var enemyMask = enemy.Type;
        var towerMask = tower.GetStats().AffectedEnemies;
        return (enemyMask & towerMask) > 0;
    }
    private bool InRange(Enemy enemy)
    {
        if (enemy == null) return false;
        return Vector2.Distance(enemy.transform.position, transform.position) < tower.GetStats().AttackRange;
    }
    private Enemy ChooseEnemyToAttack(List<Enemy> enemies)
    {
        Enemy bestCandidate = enemies[0];
        float bestCandidateDist = Vector2.Distance( bestCandidate.transform.position, transform.position);
        foreach(Enemy candidate in enemies)
        {
            if(bestCandidateDist < Vector2.Distance(bestCandidate.transform.position, transform.position))
            {
                bestCandidate = candidate;
                bestCandidateDist = Vector2.Distance(bestCandidate.transform.position, transform.position);
            }
        }
        return bestCandidate;
    }
    private void Attack(Enemy enemy)
    {
        GameObject bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.StartAttack(enemy, tower, tower.GetStats().AttackDamage);
        lastAttackTime = Time.time;
    }
}
