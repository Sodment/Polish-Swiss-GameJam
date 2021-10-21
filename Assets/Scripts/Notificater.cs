using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificater : MonoBehaviour
{
    public GameObject NotificationPrefabMoney;
    public void MakeNotificationMoney(Vector3 position, float money)
    {
        GameObject notificationMoney = Instantiate(NotificationPrefabMoney, Camera.main.WorldToScreenPoint(position), Quaternion.identity, transform);
        NotificationUI notUI = notificationMoney.GetComponent<NotificationUI>();
        notUI.startVFX(money);
    }
}
