using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Combatant
{
    string EnemyMove;
    float timeRemaining = 1;

    public string MyTurn()
    {
        
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log(timeRemaining);
            return null;
        }
        else
        {
            timeRemaining = 1;
            return "Attack";
            
        }
    }
}
