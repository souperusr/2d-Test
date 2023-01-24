using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



/*
TO DO:
    - Add another element(freeze? wind?)
    - More enemy actions
    - More player actions


*/


public enum BattleState { START, PLAYERTHINKING, PLAYERATTACKING, ENEMYTHINKING, ENEMYATTACKING, WON, LOST }

public class GameManager : MonoBehaviour
{
    public BattleState state;

    public Player Player;
    public Enemy Enemy;

    public TMPro.TextMeshProUGUI EnemyHPGUI;
    public TMPro.TextMeshProUGUI EnemyMPGUI;
    public TMPro.TextMeshProUGUI PlayerHPGUI;
    public TMPro.TextMeshProUGUI PlayerMPGUI;
    public TMPro.TextMeshProUGUI EventText;
    public string CurrentText = "";

    int Damage;

    Vector3 ENEMY_POSITION = new Vector3(4.39f, -0.05f, 0); 

    void Start()
    {
        Enemy = Instantiate(Resources.Load(SceneData.EnemyName.ToString()), ENEMY_POSITION, Quaternion.identity).GetComponent<Enemy>();
        
        state = BattleState.PLAYERTHINKING;
    }


    void Update()
    {
        PlayerHPGUI.text = Player.HP.ToString();
        EnemyHPGUI.text = Enemy.HP.ToString();
        PlayerMPGUI.text = Player.MP.ToString();
        EnemyMPGUI.text = Enemy.MP.ToString();
        EventText.text = CurrentText;

        if (Enemy.HP == 0) { state = BattleState.WON; }
        else if (Player.HP == 0) { state = BattleState.LOST; }

        if (state == BattleState.WON) { StartCoroutine(OnWin()); }
        else if (state == BattleState.LOST) { StartCoroutine(OnLose()); }
        

        if (state == BattleState.PLAYERTHINKING)
        {
            Action PlayerTurn = Player.MyTurn();
            if (PlayerTurn != null)
            {
                if (PlayerTurn.GetType() == Type.GetType("Attack"))
                {
                    int DamageHit = AttackCalc((Attack)PlayerTurn, Player, Enemy);                    
                    Damage = DamageHit;
                    Enemy.TakeDamage(DamageHit);
                    Player.MP -= PlayerTurn.MPCost;

                    CurrentText = ("You " + PlayerTurn.ActionText + Enemy.Name) ;

                    state = BattleState.PLAYERATTACKING;
                    StartCoroutine(PlayerAttack());
                }
                else if (PlayerTurn.GetType() == Type.GetType("Heal"))
                {
                    int HealHP = ((Heal)PlayerTurn).HealHP;
                    Damage = -HealHP;    

                    Player.MP -= PlayerTurn.MPCost;
                    Player.HP += HealHP;

                    CurrentText = ("You " + PlayerTurn.ActionText);

                    state = BattleState.PLAYERATTACKING;
                    StartCoroutine(PlayerAttack());
                }
                else
                {
                    throw new NotImplementedException();

                }
            }
            
        }


        else if (state == BattleState.ENEMYTHINKING)
        { // If it is the enemy's turn
            Action EnemyTurn = Enemy.MyTurn();

            if (EnemyTurn.GetType() == Type.GetType("Attack"))
            {
                int DamageHit = AttackCalc((Attack)EnemyTurn, Enemy, Player);
                Damage = DamageHit;

                CurrentText = (Enemy.Name + " " + EnemyTurn.ActionText);

                Player.TakeDamage(DamageHit);
                Enemy.MP -= EnemyTurn.MPCost;
                state = BattleState.ENEMYATTACKING;
                StartCoroutine(EnemyAttack());


            }
            else if (EnemyTurn.GetType() == Type.GetType("Heal"))
            {
                int HealHP = ((Heal)EnemyTurn).HealHP;
                Damage = -HealHP; 
                
                Enemy.HP += HealHP;
                Enemy.MP -= EnemyTurn.MPCost;

                CurrentText = (Enemy.Name + " " + EnemyTurn.ActionText);
                state = BattleState.ENEMYATTACKING;
                StartCoroutine(EnemyAttack());
            }

        }


    }

    IEnumerator OnWin ()
    {
        CurrentText = "You won!!";
        yield return new WaitForSeconds(5f);

        SceneData.Enemies[SceneData.EnemyIndex] = false;
        
        SceneData.HP = Player.HP;
        SceneData.MP = Player.MP;

        SceneManager.LoadScene("SampleScene");

    }
    IEnumerator OnLose ()
    {
        CurrentText = "You lost...";
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(1.5f);
        if (Damage >= 0)
        {
            CurrentText = (Enemy.Name + " took " + Damage + " damage");
        }
        else
        {
            CurrentText = ("You recovered " + -Damage + " HP");
        }
        yield return new WaitForSeconds(1.5f);
               
        state = BattleState.ENEMYTHINKING;

    }

    IEnumerator EnemyAttack()
    {
        
        yield return new WaitForSeconds(1.5f);
        if (Damage >= 0)
        {
            CurrentText = ("You took " + Damage + " damage");
        }
        else
        {
            CurrentText = (Enemy.Name + " recovered " + -Damage + " HP");
        }
        yield return new WaitForSeconds(1.5f);

        state = BattleState.PLAYERTHINKING;
    }




    int AttackCalc(Attack attack, Combatant Attacker, Combatant Attackee)
    {
        int baseDamage = attack.AttackDamage;
        float offense = Attacker.Offense;
        float defense = Attackee.Defense;


        int elemDamage = attack.ElemDamage;
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

        return (int)Math.Round((baseDamage * (offense / defense)) + (elemDamage / typeRes));
    }
}

