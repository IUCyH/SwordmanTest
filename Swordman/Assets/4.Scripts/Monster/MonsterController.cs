using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]
    HpBarController hpBar;
    Transform monster;
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform hpBarCenter;

    [SerializeField]
    float knockBackDuration;
    [SerializeField]
    float knockBackSpeed;
    float timer;
    [SerializeField]
    float maxHp;
    [SerializeField]
    float hp;

    bool knockBack;

    IEnumerator Coroutine_Update()
    {
        while (true)
        {
            if (knockBack)
            {
                ExecuteKnockBack();
            }
            hpBar.UpdateHpBarPosition(hpBarCenter);

            yield return null;
        }
    }
    
    public void SetDamage(float damage)
    {
        knockBack = true;
        hp -= damage;
        
        hpBar.UpdateHpBarValue(hp / maxHp);

        if (hp <= 0)
        {
            hpBar.SetAcitveFalse();
            gameObject.SetActive(false);
        }
    }

    void ExecuteKnockBack()
    {
        var dir = -player.localScale.x;

        monster.position += (dir * knockBackSpeed * Time.deltaTime * Vector3.right);

        timer += Time.deltaTime / knockBackDuration;

        if (timer > 1f)
        {
            timer = 0f;
            knockBack = false;
        }
    }

    void Start()
    {
        monster = transform;
        hp = maxHp;
        StartCoroutine(Coroutine_Update());
    }
}
