using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Combatant
{
    string EnemyMove;

    public string MyTurn()
    {
        if (Input.GetKey(KeyCode.K))
        {
            EnemyMove = "Attack";
        }
        else
        {
            EnemyMove = null;
        }
        
        return EnemyMove;
    }
}
