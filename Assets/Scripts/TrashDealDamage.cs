using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDealDamage : MonoBehaviour
{
    public GameObject DefendingZone;
    private TrashMovement trashMovement;
    private LevelManager level;
    public SpriteRenderer spriteRenderer;
    
    [SerializeField] private float DefendingRange = 0.5f;
    private void Start()
    {
        level = FindObjectOfType<LevelManager>();
        trashMovement = gameObject.GetComponent<TrashMovement>();
        if (DefendingZone == null)
        {
            DefendingZone = GameObject.FindGameObjectWithTag("DefendingZone");
            spriteRenderer = DefendingZone.GetComponent<SpriteRenderer>();
        }
    }
    void Update()
    {
        CheckIfInDefendingZone();
    }
    private void CheckIfInDefendingZone()
    {
        if (Vector2.Distance(transform.position, DefendingZone.transform.position) < DefendingRange)
        {
            EnteredDefendingZone();
        }
    }
    private void EnteredDefendingZone()
    {
        trashMovement.StopMovement();
        GameManager.Instance.baseHitPoints = Mathf.Max(0f, GameManager.Instance.baseHitPoints - 1f);
        if(GameManager.Instance.baseHitPoints <= 0f)
        {
            level.Defeat(DefendingZone);
        }
        gameObject.GetComponent<Enemy>().Die(DefendingZone.transform);
        this.enabled = false;
    }
}
