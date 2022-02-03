using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLevelSelection : MonoBehaviour
{
    public DisplayedUIPanel ChooseLevel;
    private Button _button;
    private bool IsOpen = false;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(LevelSelectionManipulation);
    }

    private void LevelSelectionManipulation()
    {
        if (!IsOpen)
        {
            ChooseLevel.OpenPanel();
        }
        else
        {
            ChooseLevel.ClosePanel();
        }
        IsOpen = !IsOpen;
    }
}
