using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerSkill playerSkill;
    [SerializeField]
    PlayerMove playerMove;
    [SerializeField]
    PlayerAttack playerAttack;
    [SerializeField]
    PlayerJump playerJump;
    
    [SerializeField]
    PlayerAnimation playerAnimation;

    bool stopAllMovement;
    
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

    public void PauseAllMovement()
    {
        stopAllMovement = true;
    }

    public void ContinueAllMovement()
    {
        stopAllMovement = false;
    }

    void Start()
    {
        playerMove.OnStart();
        playerJump.OnStart();
        playerSkill.OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopAllMovement)
        {
            StopAllAnimation();
            return;
        }
        
        playerSkill.ExecuteSkills();
        playerMove.Move();
        playerJump.CheckJump();
        playerAttack.Attack();
    }

    void FixedUpdate()
    {
        if (stopAllMovement)
        {
            StopAllAnimation();
            return;
        }
        
        playerJump.Jump();
    }
}
