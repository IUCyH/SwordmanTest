using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    Transform monster;
    [SerializeField]
    Transform player;
    [SerializeField]
    float knockBackDuration;
    [SerializeField]
    float knockBackSpeed;

    bool knockBack;

    IEnumerator Coroutine_Update()
    {
        var timer = 0f;
        
        while (true)
        {
            if (knockBack)
            {
                var dir = player.localScale.x * -1;

                monster.position += (dir * knockBackSpeed * Time.deltaTime * Vector3.right);

                timer += Time.deltaTime / knockBackDuration;

                if (timer > 1f)
                {
                    timer = 0f;
                    knockBack = false;
                }
            }

            yield return null;
        }
    }
    
    public void SetDamage()
    {
        knockBack = true;
    }

    void Start()
    {
        monster = GetComponent<Transform>();
        StartCoroutine(Coroutine_Update());
    }
}
