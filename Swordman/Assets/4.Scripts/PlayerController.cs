using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerMove playerMove;
    [SerializeField]
    PlayerAttack playerAttack;
    [SerializeField]
    PlayerJump playerJump;
    
    [SerializeField]
    PlayerAnimation playerAnimation;

    public void StopAllAnimation()
    {
        playerAnimation.StopAll();
    }
    public void PlayAnimation(PlayerMotion motion)
    {
        playerAnimation.Play(motion);
    }

    public void StopAnimation(PlayerMotion motion)
    {
        playerAnimation.Stop(motion);
    }

    public void SetAnimationSpeed(PlayerAnimSpeedParams animSpeedParam, float speed)
    {
        playerAnimation.SetAnimationSpeed(animSpeedParam, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerJump.Jumping)
        {
            playerMove.Rolling();
        }

        if(!playerMove.IsRolling)
        {
            playerMove.Move();
            playerJump.CheckJump();
            playerAttack.Attack();
        }
    }

    void FixedUpdate()
    {
        if (playerMove.IsRolling) return;
        
        playerJump.Jump();
    }
}
