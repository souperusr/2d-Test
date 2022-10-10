using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState { START, PLAYERTHINKING, PLAYERATTACKING, ENEMYTURN, WON, LOST }

public class GameManager : MonoBehaviour
{
    public BattleState state;
    
    public Player Player;
    public Enemy Enemy;

    public TMPro.TextMeshProUGUI EnemyHPGUI;
    public TMPro.TextMeshProUGUI PlayerHPGUI;
    public TMPro.TextMeshProUGUI EventText;
    public string CurrentText = "";

    float t = 2;
    
    void Start()
    {
        state = BattleState.PLAYERTHINKING;
        

    }


    void Update()
    {
        PlayerHPGUI.text = Player.HP.ToString();
        EnemyHPGUI.text = Enemy.HP.ToString();
        EventText.text = CurrentText;
        
        

        if (state == BattleState.PLAYERTHINKING)
        {
            if (Player.MyTurn() == "Attack")
            {
                CurrentText = ("You landed " + AttackCalc(Player, Enemy).ToString() + " damage on the enemy!");
                
                
                Enemy.TakeDamage(AttackCalc(Player, Enemy));
                state = BattleState.PLAYERATTACKING;
                t = 2;

            }
        }
        
        else if (state == BattleState.PLAYERATTACKING)
        {
            t -= Time.deltaTime;
            if (t < 0)
            {
                state = BattleState.ENEMYTURN;
            }
        }

        else if (state == BattleState.ENEMYTURN)
        { // If it is the enemy's turn
            if (Enemy.MyTurn() == "Attack")
            {
                CurrentText = ("Enemy guy lands " + AttackCalc(Enemy, Player).ToString() + " damage on you!");
                

                Player.TakeDamage(AttackCalc(Enemy, Player));

                state = BattleState.PLAYERTHINKING;


            }

        }

    }

    //Combatant NextCombatant()
    //{
    //    return CurrentCombatant == Player ? Enemy : Player; // Returns Current Combatant as Player if Enemy and vise versa.
    //}

    int AttackCalc(Combatant Attacker, Combatant Attackee)
    {
        return Attacker.Attack * 100 / (100 + Attackee.Strength);
    }
}

