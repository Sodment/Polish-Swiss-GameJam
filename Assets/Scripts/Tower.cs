using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private string _name;

    [Header("Attack")]
    [SerializeField] private TowerAttackInfo _defaultTowerStats;
    [SerializeField] private TowerAttackInfo[] _upgrades;

    public int CurrentUpgrade { get; set; } = -1;

    public TowerAttackInfo GetStats()
    {
        if (CurrentUpgrade < 0)
            return _defaultTowerStats;

        return _upgrades[CurrentUpgrade];
    }

    [System.Serializable]
    public struct TowerAttackInfo
    {
        public EnemyType AffectedEnemies;

        [Space]
        public float AttackRange;
        public float AttackFrequency;
        public float AttackDamage;
    }
}
