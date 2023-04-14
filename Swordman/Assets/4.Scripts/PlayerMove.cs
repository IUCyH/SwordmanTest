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
    float rollTime;
    [SerializeField]
    float rollDuration;
    [SerializeField]
    float rollSpeed;

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
        SetMoveSpeed();

        playerTransform.Translate(dir * speed * Time.deltaTime * Vector3.right);

        SetPlayerForward(dir);
        SetAnimation(dir);
    }

    public void Rolling()
    {
        float dir = playerTransform.localScale.x;

        if (!rolling && Input.GetKeyDown(KeyCode.LeftControl))
        {
            rolling = true;
            player.StopAllAnimation();
        }

        if (rolling)
        {
            Roll(dir);
        }
    }

    void Roll(float dir)
    {
        rollTime += Time.deltaTime;
        var progress = rollTime / rollDuration;

        if (progress > 1f)
        {
            rolling = false;
            rollTime = 0f;
            playerTransform.rotation = Quaternion.identity;

            return;
        }

        var angle = progress * 360f;

        playerTransform.rotation = Quaternion.Euler(0f, 0f, dir * angle);
        playerTransform.position += -dir * rollSpeed * Time.deltaTime * Vector3.right;
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
