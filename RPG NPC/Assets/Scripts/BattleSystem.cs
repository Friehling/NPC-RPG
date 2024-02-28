using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, COMPANIONTURN }

public class BattleSystem : MonoBehaviour
{
    control Control;

    public GameObject[] playerPrefab;
    public GameObject enemyPrefab;
    public GameObject companionPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    public Transform companionBattleStation;

    Unit playerUnit;
    Unit enemyUnit;
    Unit companionUnit;

    public TMP_Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        Control = GameObject.Find("controller").GetComponent<control>();
        GameObject playerGO = Instantiate(playerPrefab[Control.rember], playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        GameObject companionGO = Instantiate(companionPrefab, companionBattleStation);
        companionUnit = companionGO.GetComponent<Unit>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        
        dialogueText.text = "The attack hit, nice!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.COMPANIONTURN;
            StartCoroutine(CompanionTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + "Choose's an attack.";

        yield return new WaitForSeconds(1f);

        if (playerUnit.currentHP <= 15)
        {
            dialogueText.text = enemyUnit.unitName + "Chose attack Bite";
            bool isdead = playerUnit.TakeDamage(enemyUnit.damage*3);
            yield return new WaitForSeconds(1f);

            playerHUD.SetHP(playerUnit.currentHP);
            if (isdead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            }
        }
        else if (playerUnit.currentHP >= 15)
        {
            dialogueText.text = enemyUnit.unitName + "Chose attack claw";
            bool isdead = playerUnit.TakeDamage(enemyUnit.damage + 6);
            yield return new WaitForSeconds(1f);

            playerHUD.SetHP(playerUnit.currentHP);
            if (isdead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            }
        }
     
        
    }

    void EndBattle()
    {
        if(state == BattleState.WON) 
        {
            dialogueText.text = "You won!";
            SceneManager.LoadScene("MAP");
        }
        else if(state == BattleState.LOST)
        {
            dialogueText.text = "You lost RIP...";
            SceneManager.LoadScene("Menu");
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    IEnumerator PlayerHeal() 
    {
        playerUnit.Heal(3);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You healed";

        yield return new WaitForSeconds(2f);

        state = BattleState.COMPANIONTURN;
        StartCoroutine(CompanionTurn());
    }

    IEnumerator CompanionTurn()
    {
        dialogueText.text = "Your companion is helping you";

        yield return new WaitForSeconds(2f);

        playerUnit.Heal(1);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "Your companion healed you";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
         
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
       
    }
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());

    }
}
