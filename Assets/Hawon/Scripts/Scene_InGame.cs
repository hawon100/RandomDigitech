using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_InGame : MonoBehaviour
{
    public static Scene_InGame _Instance {  get; private set; }

    public TowerData[] towerDatas;

    public void OnClickBuyButton()
    {
        if (TileManager.Instance.IsTileMapFull())
            return;

        var ran = Random.Range(0, towerDatas.Length);

        var spawn = new Vector2Int(Random.Range(0, 5), Random.Range(0, 3));

        while (!TileManager.Instance.IsTileEmpty(spawn))
        {
            spawn = new Vector2Int(Random.Range(0, 5), Random.Range(0, 3));
        }
        TileManager.Instance.AddTower(towerDatas[ran], spawn);
    }
}
