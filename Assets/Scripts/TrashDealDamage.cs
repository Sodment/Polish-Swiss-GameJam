using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDealDamage : MonoBehaviour
{
    public Transform DefendingZone;
    [SerializeField] private float DefendingRange = 0.5f;
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
        gameObject.GetComponent<TrashMovement>().stopMovement();
        Debug.Log("Dealing damage to defending zone zone");
        Destroy(gameObject);
    }
}
