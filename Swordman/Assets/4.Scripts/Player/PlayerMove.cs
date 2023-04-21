using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    Transform playerTransform;
    
    [SerializeField]
    float runSpeed;
    [SerializeField]
    float walkSpeed;
    float speed;

    bool rolling;

    public bool IsRolling { get { return rolling; } }
    
    public void OnStart()
    {
        playerTransform = transform;
    }

    public void Move()
    {
        var dir = Input.GetAxisRaw("Horizontal");
        SetPlayerForward(dir);
        if (player.IsCannotMove(dir)) return;
        
        SetMoveSpeed();

        playerTransform.Translate(dir * speed * Time.deltaTime * Vector3.right);
        
        SetAnimation(dir);
    }
    
    void SetMoveSpeed()
    {
        var runKeyPressed = Input.GetAxisRaw("Run");

        speed = runKeyPressed > 0 ? runSpeed : walkSpeed;
    }

    void SetAnimation(float dir)
    {
        if (dir != 0)
        {
            player.PlayAnimation(PlayerMotion.Run);
        }
        else
        {
            player.StopAnimation(PlayerMotion.Run);
        }

        var animSpeed = speed - walkSpeed;
        player.SetAnimationSpeed(PlayerAnimSpeedParams.RunSpeed, animSpeed);
    }

    void SetPlayerForward(float dir)
    {
        if (dir == 0f) return;

        var scaleX = dir * -1;

        playerTransform.localScale = new Vector3(scaleX, 1f, 1f);
    }
}
