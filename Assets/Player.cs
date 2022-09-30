using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Combatant
{
    string PlayerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string MyTurn()
    {
        // Finds what action the player does and sends it to GameManager
        if (Input.GetKey(KeyCode.J)) {
            PlayerMove = "Attack";
            
        }
        else {
            PlayerMove = "None";
        }
        return PlayerMove;

        
    }
}
