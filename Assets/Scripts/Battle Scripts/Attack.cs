using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { BASIC, FIRE, ELECTRICAL }
public class Attack : Action
{

    public int AttackDamage;
    public int ElemDamage;
    public AttackType ElemType;

    public Attack(string name, string actionText, int mPCost, int attackDamage, AttackType elemType = AttackType.BASIC, int elemDamage = 0)
    {
        Name = name;
        ActionText = actionText;
        MPCost = mPCost;
        AttackDamage = attackDamage;
        ElemType = elemType;
        ElemDamage = elemDamage;




    }   
}
