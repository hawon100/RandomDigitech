using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject buttonUI;
    public GameObject creditUI;
    public GameObject exitUI;
    public void ButtonUI(string uiName)
    {
        switch (uiName)
        {
            case "setting": buttonUI.SetActive(true); break;
            case "credit": creditUI.SetActive(true); break;
            case "exit": exitUI.SetActive(true); break;
        }
    }

    public void ButtonUIdon(string uiName)
    {
        switch (uiName)
        {
            case "setting": buttonUI.SetActive(false); break;
            case "credit": creditUI.SetActive(false); break;
            case "exit": exitUI.SetActive(false); break;
        }
    }
}
