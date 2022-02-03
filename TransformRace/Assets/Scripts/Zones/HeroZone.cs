//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;

public class HeroZone : MonoBehaviour
{
    public HeroTypes ZoneType;
    public GameObject HeightGameObj;
    protected MainHero hero;
    public float height;
    private HelicopterBehavior heli;
    private HumanAnimation humanAnimation;

    private void OnTriggerStay(Collider other)
    {
        hero = other.GetComponent<MainHero>();
        if (hero)
        {
            hero.ChangeZone(ZoneType);
        }    

        height = HeightGameObj.transform.position.y;
        heli = other.gameObject.GetComponent<HelicopterBehavior>();
        if (heli)
        {
            heli.Height = height;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        hero = other.GetComponent<MainHero>();
        if (hero && other.gameObject.tag == "Enemy" && LevelManager.Instance.GameType == GameTypes.Play)
        {
            StartCoroutine(ChangeEnemyHero(hero));
            height = HeightGameObj.transform.position.y;
        }

        humanAnimation = other.gameObject.GetComponent<HumanAnimation>();
        if (humanAnimation)
        {
            if (ZoneType == HeroTypes.Human)
            {
                humanAnimation.SetBoolStairsUp();
            }
            else
            {
                humanAnimation.SetBoolRun();
            }
        }
    }

    /// <summary>
    /// меняет персонажа с задержкой в 1 сек
    /// </summary>
    private IEnumerator ChangeEnemyHero(MainHero hero)
    {
        float timeToChangeHero = Random.Range(0.0f, 3f);
        yield return new WaitForSeconds(timeToChangeHero);
        hero.ChangeHero(ZoneType);
    }
}
