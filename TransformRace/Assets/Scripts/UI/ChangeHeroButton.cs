using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHeroButton : MonoBehaviour
{
    public HeroTypes HeroType;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChangeHero);
    }
    public void ChangeHero()
    {
        LevelManager.Instance.MainHero.ChangeHero(HeroType);
    }
    
}
