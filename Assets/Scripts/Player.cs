using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Combatant
{
    KeyCode BasicAttackKey = KeyCode.D;
    KeyCode SpecialAttackKey = KeyCode.A;
    KeyCode HealKey = KeyCode.W;
    
    


    void Start()
    {
        Actions = new Action[] { new Attack("Whack", 0, 10), new Attack("Flame", 5, 15, AttackType.FIRE), new Heal("Lifeup", 50, 3)};
        
    }
    public Action MyTurn()
    {
        Action Selection = null;
        
        if (Input.GetKey(BasicAttackKey)) {
            Selection = Actions[0];
       
        }
        else if (Input.GetKey(SpecialAttackKey))
        {
            Selection = Actions[1];

        }
        else if (Input.GetKey(HealKey))
        {
            Selection = Actions[2];

        }
        if (Selection == null)
        {
            return null;
        }
        if (Selection.MPCost <= MP)
        {
            print("hi");
            return Selection;
        }
        return null;




    }
}
