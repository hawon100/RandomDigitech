using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_InGame : MonoBehaviour
{
    public static Scene_InGame _Instance { get; private set; }

    public TowerData[] towerDatas;
    public Text moneyText;
    public Image[] lifeImage;
    public Text killText;
    public Text buyText;
    public GameObject GameOverWin;

    public GameObject escapeWin;

    public int life;
    public int buyNum;
    public int money;

    bool isActive;

    private void Start()
    {
        Time.timeScale = 1;
        isActive = false;
        GameOverWin.SetActive(false);
        _Instance = this;
        life = 3;
        buyNum = 1;
        money = 100;
        StartCoroutine(MoneyGive());
    }

    private void Update()
    {
        int temp = buyNum * 10;
        moneyText.text = money.ToString();

        for(int i = 0; i < 3; i++)
        {
            lifeImage[i].gameObject.SetActive(false);
        }

        for(int i = 0; i < life; i++)
        {
            lifeImage[i].gameObject.SetActive(true);
        }

        killText.text = "Kill: " + SpawnManager._Instance.enemyKillCount.ToString();
        buyText.text = temp.ToString();


        if (money <= 0)
        {
            money = 0;
        }

        if (life <= 0)
        {
            Time.timeScale = 0;
            GameOverWin.SetActive(true);
        }
        escapeWin.SetActive(isActive);
        Escape();
    }

    private void Escape()
    {
        if (life <= 0)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
        }
    }

    public void Home()
    {
        SceneManager.LoadScene("Main");
    }

    public void Close()
    {
        isActive = false;
    }

    private IEnumerator MoneyGive()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.25f);
            money += 10;
        }
    }

    public void OnClickBuyButton()
    {
        if (TileManager.Instance.IsTileMapFull())
            return;

        if (money < buyNum * 10)
            return;

        if (life <= 0)
            return;

        var ran = Random.Range(0, towerDatas.Length);

        var spawn = new Vector2Int(Random.Range(0, 5), Random.Range(0, 3));

        while (!TileManager.Instance.IsTileEmpty(spawn))
        {
            spawn = new Vector2Int(Random.Range(0, 5), Random.Range(0, 3));
        }
        TileManager.Instance.AddTower(towerDatas[ran], spawn);

        money -= buyNum * 10;

        buyNum++;
    }
}
