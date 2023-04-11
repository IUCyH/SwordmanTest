using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    
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
}
