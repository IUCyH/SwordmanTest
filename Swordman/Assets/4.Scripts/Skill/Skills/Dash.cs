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
    
    bool canUseSkill = true;
    bool executeSkill;
    
    public void ExecuteSkill()
    {
        if (!canUseSkill) return;
        canUseSkill = false;
        
        var dir = -player.localScale.x;
        dashVector = new Vector2(player.position.x + dashDistance * dir, player.position.y);
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
            canUseSkill = true;
            cooldownTimer = 0f;
        }
    }

    void UseDash(Vector2 dashVector)
    {
        var nextDashPos = Vector2.Lerp(player.position, dashVector, dashSpeed);

        player.position = nextDashPos;
    }

    void Update()
    {
        if (!canUseSkill)
        {
            CalculateCooldown();
        }
        
        if (executeSkill)
        {
            UseDash(dashVector);
            
            skillTimer += Time.deltaTime;
            if (skillTimer > skillDuration)
            {
                executeSkill = false;
                skillTimer = 0f;
            }
        }
    }
}
