using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player Player;
    public Enemy Enemy;
    Combatant CurrentCombatant;

    public TMPro.TextMeshProUGUI EnemyHPGUI;
    public TMPro.TextMeshProUGUI PlayerHPGUI;

    void Start()
    {
        CurrentCombatant = Player;

    }


    void Update()
    {
        PlayerHPGUI.text = Player.HP.ToString();
        EnemyHPGUI.text = Enemy.HP.ToString();
        Debug.Log(CurrentCombatant);

        //print(Enemy.HP);
        if (CurrentCombatant == Player)
        { // If it is the player's turn
            if (Player.MyTurn() == "Attack")
            {
                Enemy.TakeDamage(AttackCalc(Player, Enemy));

                CurrentCombatant = NextCombatant();


            }
        }
        else if (CurrentCombatant == Enemy)
        { // If it is the enemy's turn
            if (Enemy.MyTurn() == "Attack")
            {
                Player.TakeDamage(AttackCalc(Enemy, Player));

                CurrentCombatant = NextCombatant();


            }

        }

    }

    Combatant NextCombatant()
    {
        return CurrentCombatant == Player ? Enemy : Player; // Returns Current Combatant as Player if Enemy and vise versa.
    }

    int AttackCalc(Combatant Attacker, Combatant Attackee)
    {
        return Attacker.Attack * 100 / (100 + Attackee.Strength);
    }
}

