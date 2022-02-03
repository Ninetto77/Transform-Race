using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewLevel", menuName = "LevelData/Level")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private string levelName;
    [SerializeField]
    private GameObject levelPrefab;
    [SerializeField]
    private float theBestTime;
    [SerializeField]
    private float maxCoins;
    [SerializeField]
    private float minCoins;

    public string LevelName => this.levelName;
    public GameObject LevelPrefab => this.levelPrefab;
    public float TheBestTime => this.theBestTime;
    public float MaxCoins => this.maxCoins;
    public float MinCoins => this.minCoins;
}
