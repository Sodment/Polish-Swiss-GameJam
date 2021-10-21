using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class NotificationUI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float lifetime;
    public RectTransform Transform;
    public TMP_Text tmp;
    public Image coin;
    public void startVFX(float money)
    {
        StartCoroutine(vfx(money));
    }
    private IEnumerator vfx(float money)
    {
        tmp.text = money.ToString();
        for (int i = 0; i < lifetime; i++)
        {
            Transform.position += direction.normalized * speed;
            tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, 1 -i/lifetime);
            coin.color = new Color(coin.color.r, coin.color.g, coin.color.b, 1 - i / lifetime);

            yield return null;
        }
    }
}
