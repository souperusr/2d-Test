using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Action
{
    public int HealHP;

    public Heal(string name, int healHP, int mPCost)
    {
        Name = name;
        MPCost = mPCost;
        HealHP = healHP;


    }
}
