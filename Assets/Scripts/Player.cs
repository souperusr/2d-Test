using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Combatant
{

    public TMPro.TMP_Dropdown dropdown;
    void Start()
    {
        Actions = new Action[] { new Attack("Punch", "punched ", 0, 10), new Attack("Flame", "shot a burst of flames at ", 5, 5, AttackType.FIRE, 15), new Attack("Storm", "shot lighting down on ", 7, 9, AttackType.FIRE, 20), new Heal("Lifeup", "used healing", 5, 50)};
        dropdown.options.Clear();


        foreach (Action option in Actions)
        {
            dropdown.options.Add(new TMPro.TMP_Dropdown.OptionData(option.Name));
        }

    }
    public Action MyTurn()
    {
        Action Selection = null;
        
        if (Input.GetKey(KeyCode.Space) == false)
        {
            Selection = null;
        }
        else
        {
            Selection = Actions[dropdown.value];
       
        }
        if (Selection == null)
        {
            return null;
        }
        if (Selection.MPCost <= MP)
        {
            return Selection;
        }
        else
        {
            Debug.Log("Not enough MP!");
        }
        return null;




    }
}
