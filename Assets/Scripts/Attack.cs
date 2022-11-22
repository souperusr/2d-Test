using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    
    public float PowerMult;
    

    public Attack(string name, int mPCost, int attackPower, bool isMagic)
    {
        Name = name;
        MPCost = mPCost;
        PowerMult = attackPower;
        IsMagic = isMagic;

        
    }   
}
