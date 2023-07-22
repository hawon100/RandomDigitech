using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject settingWin;

    private void Start()
    {
        settingWin.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("InGame");
        }
    }

    public void Setting(string name)
    {
        switch (name)
        {
            case "Setting": settingWin.SetActive(true); break;
            case "SettingClose": settingWin.SetActive(false); break;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
