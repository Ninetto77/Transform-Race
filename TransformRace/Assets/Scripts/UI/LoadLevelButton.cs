using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelButton : MonoBehaviour
{
    public LevelData levelData;

    private Button _button;
    private GameObject levelPrefab;


    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        var level = GameObject.FindGameObjectWithTag("Level");
        Destroy(level);
        LevelManager.Instance.ChooseLevel();
        levelPrefab = levelData.LevelPrefab;
        Instantiate(levelPrefab);

        MoneyInspector.Instance.CurrentCoins = levelData.MaxCoins;
        MoneyInspector.Instance.MinCoins = levelData.MinCoins;
        MoneyInspector.Instance.TheBestTime = levelData.TheBestTime;

    }
}
