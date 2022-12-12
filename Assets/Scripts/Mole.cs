using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Actions = new Action[] { new Attack("Throw", "threw rocks at you", 0, 10), new Attack("Bite", "bit you", 0, 25), new Heal("Burrow", "burrowed into the ground", 0, 10)};
    }

    // Update is called once per frame

    public override Action MyTurn ()
    {
        if (lastTurn == null || lastTurn.Name == "Bite")
        {
            lastTurn = Actions[0];
            return Actions[0];
        }
        else if (lastTurn.Name == "Throw")
        {
            lastTurn = Actions[2];
            return Actions[2];
        }
        else
        {
            lastTurn = Actions[1];
            return Actions[1];
        }
    }
}
