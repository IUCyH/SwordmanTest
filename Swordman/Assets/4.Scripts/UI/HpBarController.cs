using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarController : MonoBehaviour
{
    Camera camera;
    [SerializeField]
    RectTransform hpBar;
    [SerializeField]
    Image barImage;

    [SerializeField]
    float hpBarHeight;

    public void UpdateHpBarPosition(Transform monster)
    {
        var screenPos = camera.WorldToScreenPoint(monster.position);
        screenPos.y += hpBarHeight;
        
        hpBar.position = screenPos;
    }

    public void UpdateHpBarValue(float hp)
    {
        barImage.fillAmount = hp;
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    void Awake()
    {
        camera = Camera.main;
    }
}
