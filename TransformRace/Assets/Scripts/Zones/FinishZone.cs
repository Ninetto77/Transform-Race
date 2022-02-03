using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var hero = other.GetComponent<Hero>();
        if (hero)
        {
            if (LevelManager.Instance.GameType == GameTypes.Finish)
            {
                return;
            }
            if (other.gameObject.tag == "Enemy")
            {
                LevelManager.Instance.LoseLevel();
                MoneyInspector.Instance.UpdateLoseMoneyText();
                return;
            }
            LevelManager.Instance.Finish();
            MoneyInspector.Instance.SaveCoins();
            MoneyInspector.Instance.UpdateIncreasingMoneyText();
        }
    }
}
