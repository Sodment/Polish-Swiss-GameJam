using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationUI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float lifetime;
    private RectTransform Transform;
    private TMP_Text tmp;
    private void Awake()
    {
        Transform = gameObject.GetComponent<RectTransform>();
        tmp = gameObject.GetComponent<TMP_Text>();
        StartCoroutine(vfx());
    }
    private IEnumerator vfx()
    {
        for (int i = 0; i < lifetime; i++)
        {
            Transform.position += direction.normalized * speed;
            tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, 1 -i/lifetime);
            
            
            yield return null;
        }
    }
}
