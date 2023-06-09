using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    Dash dash;
    
    [SerializeField]
    PlayerController playerController;

    Dictionary<KeyCode, Skill> skillDic = new Dictionary<KeyCode, Skill>();

    public void ExecuteSkills()
    {
        foreach(var dic in skillDic)
        {
            if (dic.Value.NotReady) continue;
            
            if (Input.GetKeyDown(dic.Key))
            {
                playerController.PauseAllMovement();
                dic.Value.ExecuteSkill();
            }
        }
    }

    public void OnStart()
    {
        skillDic = new Dictionary<KeyCode, Skill>();
        InitSkillDictionary();
    }

    void InitSkillDictionary()
    {
        skillDic.Add(KeyCode.LeftControl, dash);
    }
}
