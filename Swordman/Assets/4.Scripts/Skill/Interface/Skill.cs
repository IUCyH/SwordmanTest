using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Skill
{
    bool NotReady { get; set; }
    void ExecuteSkill();
    void CalculateCooldown();
}
