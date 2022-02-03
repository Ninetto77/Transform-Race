using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyInspector : SimpleSingleton<MoneyInspector>
{
    private float usersCoins;
    [ReadOnly]
    public float CurrentCoins;
    [HideInInspector]
    public float TheBestTime;
    [HideInInspector]
    public float MinCoins;

    public float DecreasingCoins;
    public float TimeToDecreaseCoins;
    public Text MoneyText;
    public Text MoneyTextInWin;
    public Text MoneyTextInLose;

    private string MoneyID = "UsersCoins";
    private float timeToStartDecreaseCoins = 0;
    private float timeToDecreaseCoins;

    private void Start()
    {
        UpdateMoneyText();
        timeToDecreaseCoins = TimeToDecreaseCoins;
    }

    public void Update()
    {
        if (LevelManager.Instance.GameType != GameTypes.Play)
        {
            return;
        }
                  
        timeToStartDecreaseCoins += Time.deltaTime;
        if (timeToStartDecreaseCoins >= TheBestTime)
        {
            timeToDecreaseCoins -= Time.deltaTime;
            if (timeToDecreaseCoins < 0)
            {
                CurrentCoins -= DecreasingCoins;
                if (CurrentCoins < MinCoins)
                {
                    CurrentCoins = MinCoins;
                }
                timeToDecreaseCoins = TimeToDecreaseCoins;
            }
        } 
    }

    [Button("ResetCoins")]
    public bool btnss;
    public void ResetCoins()
    {
        usersCoins = 0;
        UpdateMoneyText();
    }

        public void SaveCoins()
    {
        usersCoins = GetMoney();
        usersCoins += CurrentCoins;
        PlayerPrefs.SetFloat(MoneyID, usersCoins);
        PlayerPrefs.Save();
    }

    public float GetMoney()
    {
        if (!PlayerPrefs.HasKey(MoneyID))
        {
            PlayerPrefs.SetFloat(MoneyID, 0f);
        }
        return PlayerPrefs.GetFloat(MoneyID);
    }
    public void UpdateMoneyText()
    {
        usersCoins = GetMoney();
        MoneyText.text = usersCoins.ToString();
    }

    public void UpdateIncreasingMoneyText()
    {
        MoneyTextInWin.text = " + " + CurrentCoins.ToString();
    }
    public void UpdateLoseMoneyText()
    {
        MoneyTextInLose.text = "+ 0";
    }

}
