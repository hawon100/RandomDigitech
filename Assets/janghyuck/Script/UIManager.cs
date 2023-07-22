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

    bool isActivecredit;
    bool isActivesetting;
    bool isActiveexit;
    public void ButtonUI(string uiName)
    {
        switch (uiName)
        {
            case "setting": isActivesetting = true; break;
            case "credit": isActivecredit = true; break;
            case "exit": isActiveexit = true; break;
        }
    }

    public void ButtonUIdon(string uiName)
    {
        switch (uiName)
        {
            case "setting": isActivesetting = false; break;
            case "credit": isActivecredit = false; break;
            case "exit": isActiveexit = false; break;
        }
    }

    private void Start()
    {
        isActivesetting = false;
        isActivecredit = false;
        isActiveexit = false;
    }

    private void Update()
    {
        if (isActivesetting)
        {
            Scenes[0].anchoredPosition = Vector3.Lerp(Scenes[0].anchoredPosition, posSquareOne, 0.1f);
        }
        if (!isActivesetting)
        {
            Scenes[0].anchoredPosition = Vector3.Lerp(Scenes[0].anchoredPosition, pos, 0.1f);
        }
        if (isActivecredit)
        {
            Scenes[1].anchoredPosition = Vector3.Lerp(Scenes[1].anchoredPosition, posSquareOne, 0.1f);
        }
        if (!isActivecredit)
        {
            Scenes[1].anchoredPosition = Vector3.Lerp(Scenes[1].anchoredPosition, pos, 0.1f);
        }
        if (isActiveexit)
        {
            Scenes[2].anchoredPosition = Vector3.Lerp(Scenes[2].anchoredPosition, posSquareOne, 0.1f);
        }
        if (!isActiveexit)
        {
            Scenes[2].anchoredPosition = Vector3.Lerp(Scenes[2].anchoredPosition, pos, 0.1f);
        }
    }
}
