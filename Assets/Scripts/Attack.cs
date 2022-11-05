using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    
    public float PowerMult;
    

    public Attack(string name, int mPCost, float powerMult, bool isMagic)
    {
        Name = name;
        MPCost = mPCost;
        PowerMult = powerMult;
        IsMagic = isMagic;

        
    }   
}
