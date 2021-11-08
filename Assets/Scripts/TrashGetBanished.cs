using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGetBanished : MonoBehaviour
{
    public void getBannished()
    {
        gameObject.GetComponent<TrashMovement>().StopMovement();
        Debug.Log("im banished and playing awersome visual effect");
        Destroy(gameObject);
    }
}
