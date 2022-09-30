using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player Player;
    public Combatant Enemy;
    Combatant CurrentCombatant;
    // Start is called before the first frame update
    void Start()
    {
        CurrentCombatant = Player;
    }

    // Update is called once per frame
    void Update()
    {
        print(AttackCalc(Player, Enemy));
        if (CurrentCombatant == Player) {
            if (Player.MyTurn() == "Attack") {
                
            }
        }
    }

    int AttackCalc(Combatant Attacker, Combatant Attackee)
    {
        return Attacker.Attack * 100/(100 + Attackee.Strength);
    }
}

