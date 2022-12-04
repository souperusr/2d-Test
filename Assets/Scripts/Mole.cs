using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Actions = new Action[] { new Attack("Bite", 0, 1), new Heal("Burrow", 20, 0)};
    }

    // Update is called once per frame

    public override Action MyTurn ()
    {
        if (lastTurn == null || lastTurn.Name == "Bite")
        {
            lastTurn = Actions[1];
            return Actions[1];
        }
        else
        {
            lastTurn = Actions[0];
            return Actions[0];
        }
    }
}
