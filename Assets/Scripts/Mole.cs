using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Actions = new Action[] { new Attack("Bite", 0, 1, false), new Heal("Burrow", 20, 0, false) };
    }

    // Update is called once per frame
    
    public override Action MyTurn()
    {
        if (HP < 10) {
            return Actions[1];
        }
        else
        {
            return Actions[0];
        }
    }
}
