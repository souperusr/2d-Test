using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Combatant
{
    public Action lastTurn;

    void Start()
    {
        Actions = new Action[] { new Attack("Attack", 0, 1)};
}

    public abstract Action MyTurn ();
    




}
