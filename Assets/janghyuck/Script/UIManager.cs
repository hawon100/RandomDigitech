using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public RectTransform[] Scenes;
    Vector2 posSquareOne = new Vector2(0, 0);
    Vector2 pos = new Vector2(2000, 0);
    public GameObject settingUI;
    public GameObject creditUI;
    public GameObject exitUI;


    bool issetting;
    bool iscredit;
    bool isexit;
    public void ButtonUI(string uiName)
    {
        switch (uiName)
        {
            case "setting": issetting = true; break;
            case "credit": iscredit = true; break;
            case "exit": isexit = true; break;
        }
    }

    public void ButtonUIdon(string uiName)
    {
        switch (uiName)
        {
            case "setting": issetting = false; break;
            case "credit": iscredit = false; break;
            case "exit": isexit = false; break;
        }
    }

    void Start()
    {
        issetting = false;
        iscredit = false;
        isexit = false;
    }

    void Update()
    {
        if (issetting)
        {
            Scenes[0].anchoredPosition = Vector3.Lerp(Scenes[0].anchoredPosition, posSquareOne, 0.1f);
        }
        if (!issetting)
        {
            Scenes[0].anchoredPosition = Vector3.Lerp(Scenes[0].anchoredPosition, pos, 0.1f);
        }
        if (iscredit)
        {
            Scenes[1].anchoredPosition = Vector3.Lerp(Scenes[1].anchoredPosition, posSquareOne, 0.1f);
        }
        if (!iscredit)
        {
            Scenes[1].anchoredPosition = Vector3.Lerp(Scenes[1].anchoredPosition, pos, 0.1f);
        }
        if (isexit)
        {
            Scenes[2].anchoredPosition = Vector3.Lerp(Scenes[2].anchoredPosition, posSquareOne, 0.1f);
        }
        if (!isexit)
        {
            Scenes[2].anchoredPosition = Vector3.Lerp(Scenes[2].anchoredPosition, pos, 0.1f);
        }
    }
}
