﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    public PlayerHealth playerHealth;
    public PlayerDamage playerDamage;
    public EnemyHealth enemyHealth;

    public MonoBehaviour enemyBehaviour;

    public AttackBar attackBar;

    public GameObject battleObj;
    public GameObject gameOver;

    public GameObject battleOptions;

    public GameObject fight;

    public GameObject playerMovement;
    public GameObject playerHealthUI;

    private void OnEnable()
    {
        instance = this;

        playerHealth = FindObjectOfType<PlayerHealth>();
        playerDamage = FindObjectOfType<PlayerDamage>();
        enemyHealth = FindObjectOfType<EnemyHealth>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PlayerTurn()
    {
        TogglePlayerMovement(false);
        ToggleBattleOptions(true);
    }

    public void EnemyTurn()
    {
        playerHealth.ToggleInvincibility(false);
        TogglePlayerMovement(true);
        ToggleBattleOptions(false);
        enemyBehaviour.SendMessage("Attack");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ToggleBattleOptions(bool toggle)
    {
        battleOptions.SetActive(toggle);
    }

    public void ToggleFight(bool toggle)
    {
        fight.SetActive(toggle);
        attackBar.ToggleMovement(toggle);

        if (!toggle)
        {
            attackBar.transform.localPosition = Vector2.left * 3.825f;
        }
    }

    public void TogglePlayerMovement(bool toggle)
    {
        playerMovement.SetActive(toggle);
        playerHealthUI.SetActive(toggle);
    }
}