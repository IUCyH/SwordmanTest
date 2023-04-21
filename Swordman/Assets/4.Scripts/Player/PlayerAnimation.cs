using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;


public enum PlayerMotion
{
    None = -1,
    Idle,
    Run,
    Attack,
    Jump,
    Sit,
    Die,
    Max
}

public enum PlayerAnimSpeedParams
{
    None = -1,
    RunSpeed,
    Max
}

public class PlayerAnimation : MonoBehaviour
{
    StringBuilder sb = new StringBuilder();
    Dictionary<PlayerMotion, int> animations = new Dictionary<PlayerMotion, int>();
    Dictionary<PlayerAnimSpeedParams, int> animSpeedParams = new Dictionary<PlayerAnimSpeedParams, int>();

    Animator animator;

    public void StopAll()
    {
        foreach (KeyValuePair<PlayerMotion, int> motion in animations)
        {
            if (animator.GetBool(motion.Value))
            {
                Stop(motion.Key);
            }
        }
    }
    
    public void Play(PlayerMotion motion)
    {
        animator.SetBool(animations[motion], true);
    }

    public void Stop(PlayerMotion motion)
    {
        animator.SetBool(animations[motion], false);
    }

    public void SetAnimationSpeed(PlayerAnimSpeedParams animSpeedParam, float speed = 1f)
    {
        if (Mathf.Approximately(speed, 0f)) speed = 1f;
        
        animator.SetFloat(animSpeedParams[animSpeedParam], speed);
    }

    void Start()
    {
        foreach (PlayerMotion motion in Enum.GetValues(typeof(PlayerMotion)))
        {
            if(motion is PlayerMotion.None or PlayerMotion.Max) continue;

            sb.Append(motion);
            var id = Animator.StringToHash(sb.ToString());
            animations.Add(motion, id);
            
            sb.Clear();
        }
        
        foreach (PlayerAnimSpeedParams animSpeedParam in Enum.GetValues(typeof(PlayerAnimSpeedParams)))
        {
            if(animSpeedParam is PlayerAnimSpeedParams.None or PlayerAnimSpeedParams.Max) continue;

            sb.Append(animSpeedParam);
            var id = Animator.StringToHash(sb.ToString());
            animSpeedParams.Add(animSpeedParam, id);
            
            sb.Clear();
        }

        animator = GetComponent<Animator>();
    }
}
