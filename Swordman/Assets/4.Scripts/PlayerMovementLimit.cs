using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLimit : MonoBehaviour
{
    [SerializeField]
    Transform player;
    int monsterLayer;
    [SerializeField]
    float raycastDistance;
    
    public bool IsCannotMove(float dir)
    {
        bool cannotMove = Physics2D.Raycast(player.position, dir * Vector2.right, raycastDistance, monsterLayer);
        Debug.DrawRay(player.position, dir * raycastDistance * Vector2.right, Color.green);
        
        return cannotMove;
    }

    void Start()
    {
        monsterLayer = 1 << LayerMask.NameToLayer("Monster");
    }
}
