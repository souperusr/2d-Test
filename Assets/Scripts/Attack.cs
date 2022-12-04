using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { BASIC, FIRE, ELECTRICAL }
public class Attack : Action
{

    public int AttackDamage;
    public AttackType ElemType;

    public Attack(string name, int mPCost, int attackDamage, AttackType elemType = AttackType.BASIC)
    {
        Name = name;
        MPCost = mPCost;
        AttackDamage = attackDamage;
        ElemType = elemType;
        

        
    }   
}
