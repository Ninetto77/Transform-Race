using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainHero : MonoBehaviour
{
    public List<Hero> Heroes;
    public Hero HeroNow;   
    
    private Rigidbody _rigidbody;
    private Vector3 speed;
    private Vector3 oldSpeed;
    private HelicopterBehavior heli;
    private float helicopterHeight;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        foreach (var hero in Heroes)
        {
            hero.gameObject.SetActive(false);
        }
        HeroNow.gameObject.SetActive(true);
        heli = GetComponentInChildren<HelicopterBehavior>();
    }

    private void Update()
    {
        if(LevelManager.Instance.GameType != GameTypes.Play)
            return;

        if (heli)
        {
            if (transform.position.y < heli.Height)
            {
                speed = heli.GetVector3SpeedUp();
            }
            else
            {
                speed = heli.GetVector3SpeedForward();
            }
        }
        _rigidbody.velocity = new Vector3(speed.x >= 0 ? speed.x : _rigidbody.velocity.x,
                                          speed.y >= 0 ? speed.y : _rigidbody.velocity.y, 
                                          speed.z >= 0 ? speed.z : _rigidbody.velocity.z);
    }


    public void ChangeHero(HeroTypes heroType)
    {
        HeroNow.gameObject.SetActive(false);
        
        FindHero(ref HeroNow, heroType);
        
        HeroNow.gameObject.SetActive(true);
    }

    public void ChangeZone(HeroTypes zoneType)
    {
        speed = HeroNow.GetSpeedByZone(zoneType);
        heli = GetComponentInChildren<HelicopterBehavior>();
        if (heli)
        {
            heli.SetVector3SpeedForward(speed);
        }
    }
    
    /// <summary>
    /// находит персонажа по его типу
    /// </summary>
    /// <param name="hero"> Сюда будет записан выбранный персонаж, его ссылка</param>
    /// <param name="heroType"> Тип персонажа</param>
    /// <returns></returns>
    public Hero FindHero(ref Hero hero, HeroTypes heroType)
    {
        foreach (var _hero in Heroes)
        {
            if (_hero.HeroType == heroType)
            {
                hero = _hero;
            }
        }

        return null;
    }
}