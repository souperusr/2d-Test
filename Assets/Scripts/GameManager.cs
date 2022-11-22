using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTHINKING, PLAYERATTACKING, ENEMYATTACKING, WON, LOST }

public class GameManager : MonoBehaviour
{
    public BattleState state;

    public Player Player;
    public Mole Enemy;

    public TMPro.TextMeshProUGUI EnemyHPGUI;
    public TMPro.TextMeshProUGUI PlayerHPGUI;
    public TMPro.TextMeshProUGUI EventText;
    public string CurrentText = "";


    void Start()
    {
        state = BattleState.PLAYERTHINKING;


    }


    void Update()
    {
        PlayerHPGUI.text = Player.HP.ToString();
        EnemyHPGUI.text = Enemy.HP.ToString();
        EventText.text = CurrentText;

        if (Player.HP < 0)
        {
            state = BattleState.LOST;
            CurrentText = "You lost...";
            SceneManager.LoadScene("SampleScene");



        }

     

        if (state == BattleState.PLAYERTHINKING)
        {
            Action PlayerTurn = Player.MyTurn();
            if (PlayerTurn != null)
            {
                if (PlayerTurn.GetType() == Type.GetType("Attack"))
                {
                    int DamageHit = AttackCalc((Attack)PlayerTurn, Player, Enemy);
                    CurrentText = ("You landed " + DamageHit.ToString() + " damage on the enemy!");

                    Enemy.TakeDamage(DamageHit);
                    state = BattleState.PLAYERATTACKING;
                    StartCoroutine(PlayerAttack());
                }
                else if (PlayerTurn.GetType() == Type.GetType("Heal"))
                {
                    int HealHP = ((Heal)PlayerTurn).HealHP;
                    Player.HP += HealHP;

                    CurrentText = ("You recovered " + HealHP + " health!");
                    state = BattleState.PLAYERATTACKING;
                    StartCoroutine(PlayerAttack());
                }
                else
                {
                    throw new NotImplementedException();

                }
            }
            
        }


        else if (state == BattleState.ENEMYATTACKING)
        { // If it is the enemy's turn
            Action EnemyTurn = Enemy.MyTurn();

            if (EnemyTurn.GetType() == Type.GetType("Attack"))
            {
                int DamageHit = AttackCalc((Attack)EnemyTurn, Enemy, Player);
                CurrentText = (Enemy.Name + " landed " + DamageHit.ToString() + " damage on you!");

                Player.TakeDamage(DamageHit);
                
            }
            else if (EnemyTurn.GetType() == Type.GetType("Heal"))
            {
                int HealHP = ((Heal)EnemyTurn).HealHP;
                Enemy.HP += HealHP;

                CurrentText = (Enemy.Name + " recovered " + HealHP + " HP");
            }
            state = BattleState.PLAYERTHINKING;

        }


    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYATTACKING;

    }




    //Combatant NextCombatant()
    //{
    //    return CurrentCombatant == Player ? Enemy : Player; // Returns Current Combatant as Player if Enemy and vise versa.
    //}

    int AttackCalc(Attack attack, Combatant Attacker, Combatant Attackee)
    {
        return (int)Math.Round(Attacker.Offense * attack.PowerMult * 100 / (100 + Attackee.Defense));
    }
}

