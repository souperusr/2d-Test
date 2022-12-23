using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : Enemy
{
    // Start is called before the first frame update
    void Start ()
    {
        Actions = new Action[] { new Attack("Bite", "bit you", 0, 10)};
    }

    // Update is called once per frame

    public override Action MyTurn ()
    {
        return Actions[0];
    }
}