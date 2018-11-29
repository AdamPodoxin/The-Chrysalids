﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public GameObject textBox;
    public Text text;

    private Coroutine lastCoroutine;

    private IEnumerator SayTextCoroutine(string text, float lettersPerSec, float timeUntilBoxDisables)
    {
        float waitTime = 1f / lettersPerSec;

        textBox.SetActive(true);
        this.text.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitForSeconds(timeUntilBoxDisables);
        HideTextBox();
    }

    private IEnumerator SayTextCoroutine(string text, float lettersPerSec, System.Func<bool> conditionToDisableBox)
    {
        float waitTime = 1f / lettersPerSec;

        textBox.SetActive(true);
        this.text.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitUntil(conditionToDisableBox);
        HideTextBox();
    }

    private IEnumerator SayTextCoroutine(string text, float lettersPerSec, float timeUntilBoxDisables, Items.EnemyTurnAfterItem enemyTurnAfterItem)
    {
        float waitTime = 1f / lettersPerSec;

        textBox.SetActive(true);
        this.text.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitForSeconds(timeUntilBoxDisables);
        enemyTurnAfterItem();
        HideTextBox();
    }

    private IEnumerator SayTextCoroutine(string text, float lettersPerSec, System.Func<bool> conditionToDisableBox, Items.EnemyTurnAfterItem enemyTurnAfterItem)
    {
        float waitTime = 1f / lettersPerSec;

        textBox.SetActive(true);
        this.text.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitUntil(conditionToDisableBox);
        enemyTurnAfterItem();
        HideTextBox();
    }

    public void SayText(string text, float lettersPerSec, float timeUntilBoxDisables)
    {
        lastCoroutine = StartCoroutine(SayTextCoroutine(text, lettersPerSec, timeUntilBoxDisables));
    }

    public void SayText(string text, float lettersPerSec, System.Func<bool> conditionToDisableBox)
    {
        lastCoroutine = StartCoroutine(SayTextCoroutine(text, lettersPerSec, conditionToDisableBox));
    }

    public void SayText(string text, float lettersPerSec, float timeUntilBoxDisables, Items.EnemyTurnAfterItem enemyTurnAfterItem)
    {
        lastCoroutine = StartCoroutine(SayTextCoroutine(text, lettersPerSec, timeUntilBoxDisables, enemyTurnAfterItem));
    }

    public void SayText(string text, float lettersPerSec, System.Func<bool> conditionToDisableBox, Items.EnemyTurnAfterItem enemyTurnAfterItem)
    {
        lastCoroutine = StartCoroutine(SayTextCoroutine(text, lettersPerSec, conditionToDisableBox, enemyTurnAfterItem));
    }

    public void HideTextBox()
    {
        if (lastCoroutine != null)
        {
            StopCoroutine(lastCoroutine);
        }

        textBox.SetActive(false);
    }
}
