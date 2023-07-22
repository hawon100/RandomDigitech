using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_InGame : MonoBehaviour
{
    public static Scene_InGame _Instance { get; private set; }

    public TowerData[] towerDatas;
    public Text moneyText;
    public Image[] lifeImage;
    public GameObject GameOverWin;

    public int life;
    int buyNum;
    int money;

    private void Start()
    {
        GameOverWin.SetActive(false);
        _Instance = this;
        life = 3;
        buyNum = 1;
        money = 10;
        StartCoroutine(MoneyGive());
    }

    private void Update()
    {
        moneyText.text = "$ " + money.ToString();

        if (money <= 0)
        {
            money = 0;
        }

        if (life <= 0)
        {
            Time.timeScale = 0;
            GameOverWin.SetActive(true);
        }
    }

    private IEnumerator MoneyGive()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            money += 10;
        }
    }

    public void OnClickBuyButton()
    {
        if (TileManager.Instance.IsTileMapFull())
            return;

        if (money <= 0)
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
