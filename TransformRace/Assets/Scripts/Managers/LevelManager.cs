using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameTypes
{
    Play,
    Menu,
    Finish
}
public enum HeroTypes
{
    Human,
    Car,
    Boat,
    Helicopter
}
public class LevelManager : SimpleSingleton<LevelManager>
{
    public Level Level;
    public MainHero MainHero;
    public GameObject UsersMoney;
    public LevelData levelData;
    public Button OpenLevelSelectionBtn;

    [Header("UI")]
    public DisplayedUIPanel MainMenuWindow;
    public DisplayedUIPanel MenuWindow;
    public DisplayedUIPanel GameWindow;
    public DisplayedUIPanel FinishWindow;
    public DisplayedUIPanel LoseLevelWindow;


    [NonSerialized] public GameTypes GameType = GameTypes.Menu;
    private GameObject levelPrefab;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 0;
    }

    private void Start()
    {
        levelPrefab = levelData.LevelPrefab;
        Instantiate(levelPrefab);

        MoneyInspector.Instance.CurrentCoins = levelData.MaxCoins;
        MoneyInspector.Instance.MinCoins = levelData.MinCoins;
        MoneyInspector.Instance.TheBestTime = levelData.TheBestTime;
    }

    public void ChooseLevel()
    {
        MainMenuWindow.OpenPanel();
        MenuWindow.OpenPanel();
        FinishWindow.ClosePanel();
    }

    public void StartGame()
    {
        OpenLevelSelectionBtn.gameObject.SetActive(false);
        MainMenuWindow.ClosePanel();
        GameType = GameTypes.Play;
        MenuWindow.ClosePanel();
        GameWindow.OpenPanel();
        FinishWindow.ClosePanel();
        Time.timeScale = 1;
    }

    public void Finish()
    {
        GameType = GameTypes.Finish;
        MenuWindow.ClosePanel();
        GameWindow.ClosePanel();
        FinishWindow.OpenPanel();
    }

    public void LoseLevel()
    {
        GameType = GameTypes.Finish;
        MenuWindow.ClosePanel();
        GameWindow.ClosePanel();
        LoseLevelWindow.OpenPanel();
    }
}
