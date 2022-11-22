using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Combatant
{
    KeyCode BasicAttackKey = KeyCode.K;
    KeyCode SpecialAttackKey = KeyCode.J;
    KeyCode HealKey = KeyCode.L;
    


    void Start()
    {
        Actions = new Action[] { new Attack("Whack", 0, 3, false), new Attack("Flame", 5, 1, true), new Heal("Lifeup", 50, 3, true)};
        
    }
    public Action MyTurn()
    { 
        if (Input.GetKey(BasicAttackKey)) {
            return Actions[0];
       
        }
        if (Input.GetKey(SpecialAttackKey))
        {
            return Actions[1];

        }
        if (Input.GetKey(HealKey))
        {
            return Actions[2];

        }
        return null;

        
    }
}
