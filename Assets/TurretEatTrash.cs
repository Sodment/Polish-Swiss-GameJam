using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEatTrash : MonoBehaviour
{
    public Tower tower;

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
            if(enemiesInRange?.Count > 0)
            {
                Enemy enemyToAttack = ChooseEnemyToAttack(enemiesInRange);
                Attack(enemyToAttack);
            }
        }
    }
    private List<Enemy> GetEnemiesInRange(float range)
    {
        return null;
    }
    private Enemy ChooseEnemyToAttack(List<Enemy> enemies)
    {
        Enemy bestCandidate = enemies[0];
        float bestCandidateDist = bestCandidate.givemedist();
        foreach(Enemy candidate in enemies)
        {
            if(bestCandidateDist < candidate.givemedist())
            {
                bestCandidate = candidate;
                bestCandidateDist = candidate.givemedist();
            }
        }
        return bestCandidate;
    }
    private void Attack(Enemy enemy)
    {
        enemy.DealDamage(tower.GetStats().AttackDamage);
    }
}
