using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Combatant : MonoBehaviour
{
    public string Name;

    public int HP = 50;
    public int MP = 20;
    
    public int MaxHP = 50;
    public int MaxMP = 20;
    public int Offense = 8;
    public int Defense = 6;
    public int Mobility = 4;
    public int Magic = 6;

    public Action[] Actions;

    public int TakeDamage(int damage) {
        HP -= damage;
        return HP;
    }
    int AttackCalc(Combatant Attacker, Combatant Attackee)
    {
        return Attacker.Offense * 100 / (100 + Attackee.Defense);
    }

    void Update ()
    {
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
        else if (MP > MaxMP)
        {
            MP = MaxMP;
        }
        
        else if (HP < 0)
        {
            HP = 0;
        }

        else if (MP < 0)
        {
            MP = 0;
        }
    }


}
