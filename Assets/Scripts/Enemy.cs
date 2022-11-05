using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Combatant
{
    
    void Start()
    {
        Actions = new Action[] { new Attack("Fire", 4, 1.5f, true), new Attack("Freeze", 18, 4f, true)};
}
    
    public Action MyTurn()
    {
        return Actions[0];
        
    }




}
