using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Combatant
{
    
    void Start()
    {
        Actions = new Action[] { new Attack("Attack", 0, 1, false),};
}

    public abstract Action MyTurn ();
    




}
