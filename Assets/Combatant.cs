using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combatant : MonoBehaviour
{
    public int HP = 50;
    public int MP = 20;
    public int Attack = 8;
    public int Strength = 6;
    public int Mobility = 4;
    public int Magic = 6;

    //string[] names = new string["10"]; Items

    public int TakeDamage(int damage) {
        HP -= damage;
        return HP;
    }

    
}
