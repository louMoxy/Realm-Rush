using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }
    [SerializeField] Text goldText;

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateUIText();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateUIText();
    }


    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateUIText();
        if (currentBalance < 0) {
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdateUIText()
    {
        goldText.text = $"Gold: {currentBalance}";
    }
}
