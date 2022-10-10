using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Combatant
{
    string PlayerMove;

    public string MyTurn()
    {
        // Finds what action the player does and sends it to GameManager
        if (Input.GetKey(KeyCode.J)) {
            PlayerMove = "Attack";
       
        }
        else 
        {
            PlayerMove = null;
        }
        return PlayerMove;

        
    }
}
