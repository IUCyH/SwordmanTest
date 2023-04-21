using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour, Skill
{
    StringBuilder sb = new StringBuilder();
    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    Transform player;
    [SerializeField]
    Text cooldownText;
    Vector2 dashVector;

    [SerializeField]
    float dashDistance;
    [SerializeField]
    float dashSpeed;
    [SerializeField]
    float coolDown;
    float cooldownTimer;
    [SerializeField]
    float skillDuration;
    float skillTimer;
    float dashDir;
    
    bool executeSkill;
    
    public bool NotReady { get; set; }
    
    public void ExecuteSkill()
    {
        NotReady = true;
        
        dashDir = -player.localScale.x;
        dashVector = new Vector2(player.position.x + dashDistance * dashDir, player.position.y);
        executeSkill = true;
    }

    public void CalculateCooldown()
    {
        cooldownTimer += Time.deltaTime;
        
        sb.Clear();
        sb.AppendFormat("Dash : {0:0.00}", cooldownTimer);
        cooldownText.text = sb.ToString();
        
        if (cooldownTimer >= coolDown)
        {
            NotReady = false;
            cooldownTimer = 0f;
        }
    }

    void UseDash()
    {
        if (playerController.IsCannotMove(dashDir)) return;

        var nextDashPos = Vector2.Lerp(player.position, dashVector, dashSpeed);

        player.position = nextDashPos;
    }

    void Update()
    {
        if (NotReady)
        {
            CalculateCooldown();
        }
        
        if (executeSkill)
        {
            UseDash();
            
            skillTimer += Time.deltaTime;
            if (skillTimer > skillDuration)
            {
                executeSkill = false;
                skillTimer = 0f;
                playerController.ContinueAllMovement();
            }
        }
    }
}
