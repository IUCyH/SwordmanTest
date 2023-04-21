using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    FindMonsters attackArea;
    [SerializeField]
    float defaultDamage;
    
    public void Attack()
    {
        var attackKeyPressed = Input.GetAxisRaw("Attack");
        
        if (attackKeyPressed > 0)
        {
            player.PlayAnimation(PlayerMotion.Attack);
        }
        else
        {
            player.StopAnimation(PlayerMotion.Attack);
        }
    }

    public void AnimEvent_OnAttackFinished()
    {
        var monsters = attackArea.monsters;
        if(monsters.Count < 0) return;

        for (int i = 0; i < monsters.Count; i++)
        {
            var mon = monsters[i].GetComponent<MonsterController>();
            if(mon == null) continue;
            
            mon.SetDamage(defaultDamage);
        }
    }
}
