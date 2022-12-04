using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
TO DO:
    - Elements
    - UI
    - Attack calc
    
    - MP checker

*/


public enum BattleState { START, PLAYERTHINKING, PLAYERATTACKING, ENEMYATTACKING, WON, LOST }

public class GameManager : MonoBehaviour
{
    public BattleState state;

    public Player Player;
    public Mole Enemy;

    public TMPro.TextMeshProUGUI EnemyHPGUI;
    public TMPro.TextMeshProUGUI EnemyMPGUI;
    public TMPro.TextMeshProUGUI PlayerHPGUI;
    public TMPro.TextMeshProUGUI PlayerMPGUI;
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
        PlayerMPGUI.text = Player.MP.ToString();
        EnemyMPGUI.text = Enemy.MP.ToString();
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

                    Enemy.TakeDamage(DamageHit);
                    Player.MP -= PlayerTurn.MPCost;

                    CurrentText = ("You landed " + DamageHit.ToString() + " damage on the enemy!");

                    state = BattleState.PLAYERATTACKING;
                    StartCoroutine(PlayerAttack());
                }
                else if (PlayerTurn.GetType() == Type.GetType("Heal"))
                {
                    int HealHP = ((Heal)PlayerTurn).HealHP;
                    
                    Player.MP -= PlayerTurn.MPCost;
                    Player.HP += HealHP;

                    CurrentText = ("You recovered " + HealHP + " HP!");

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
                Enemy.MP -= EnemyTurn.MPCost;


            }
            else if (EnemyTurn.GetType() == Type.GetType("Heal"))
            {
                int HealHP = ((Heal)EnemyTurn).HealHP;
                
                Enemy.HP += HealHP;
                Enemy.MP -= EnemyTurn.MPCost;

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
        float typeRes;

        if (attack.ElemType == AttackType.FIRE)
        {
            typeRes = Attackee.FireRes;
        }
        else if (attack.ElemType == AttackType.ELECTRICAL)
        {
            typeRes = Attackee.ElecRes;
        }
        else
        {
            typeRes = 1;
        }
        return (int)Math.Round(Attacker.Offense * attack.AttackDamage / typeRes * 100 / (100 + Attackee.Defense));
    }
}

