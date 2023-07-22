using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour
{
    public GameObject buttonUI;
    public GameObject creditUI;
    public void ButtonUI(string uiName)
    {
        switch (uiName)
        {
            case "setting": buttonUI.SetActive(true); break;
            case "credit": buttonUI.SetActive(true); break;
        }
    }

    public void ButtonUIdon(string uiName)
    {
        switch (uiName)
        {
            case "setting": buttonUI.SetActive(false); break;
            case "credit": buttonUI.SetActive(false); break;
        }
    }
}
