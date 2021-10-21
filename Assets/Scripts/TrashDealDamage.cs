using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDealDamage : MonoBehaviour
{
    public Transform DefendingZone;
    private TrashMovement trashMovement;
    public SpriteRenderer spriteRenderer;
    public Sprite deadBase;
    [SerializeField] private float DefendingRange = 0.5f;
    private void Start()
    {
        trashMovement = gameObject.GetComponent<TrashMovement>();
        if (DefendingZone == null)
        {
            DefendingZone = GameObject.FindGameObjectWithTag("DefendingZone").transform;
            spriteRenderer = DefendingZone.GetComponent<SpriteRenderer>();
        }
    }
    void Update()
    {
        CheckIfInDefendingZone();
    }
    private void CheckIfInDefendingZone()
    {
        if (Vector2.Distance(transform.position, DefendingZone.position) < DefendingRange)
        {
            EnteredDefendingZone();
        }
    }
    private void EnteredDefendingZone()
    {
        trashMovement.stopMovement();
        GameManager.Instance.baseHitPoints -= DefendingRange;
        Debug.Log("Dealing damage to defending zone zone");
        if(GameManager.Instance.baseHitPoints <= 0.0f)
        {
            spriteRenderer.sprite = deadBase;
        }
        gameObject.GetComponent<Enemy>().Die();
        Destroy(this);
    }
}
