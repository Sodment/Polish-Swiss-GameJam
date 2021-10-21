using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificater : MonoBehaviour
{
    public GameObject NotificationPrefabMoney;
    public GameObject NotificationPrefabNotEnoughMoney;
    public void MakeNotificationMoney(Vector3 position, float money)
    {
        GameObject notificationMoney = Instantiate(NotificationPrefabMoney, Camera.main.WorldToScreenPoint(position), Quaternion.identity, transform);
        NotificationUI notUI = notificationMoney.GetComponent<NotificationUI>();
        notUI.startVFX(money);
    }
    public void MakeNotificationNotEnoughMoney(Vector3 position)
    {
        GameObject notificationMoney = Instantiate(NotificationPrefabNotEnoughMoney, position, Quaternion.identity, transform);
        NotificationUI notUI = notificationMoney.GetComponent<NotificationUI>();
        notUI.startVFXNot();
    }
}
