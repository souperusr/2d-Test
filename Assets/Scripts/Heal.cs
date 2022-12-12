using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Action
{
    public int HealHP;

    public Heal(string name, string actionText, int mPCost, int healHP)
    {
        Name = name;
        ActionText = actionText;
        MPCost = mPCost;
        HealHP = healHP;


    }
}
