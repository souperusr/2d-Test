using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Action
{
    public int HealHP;

    public Heal(string name, int healHP, int mPCost, bool isMagic)
    {
        Name = name;
        MPCost = mPCost;
        IsMagic = isMagic;
        HealHP = healHP;


    }
}
