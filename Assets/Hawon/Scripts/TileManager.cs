using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance { get; private set; }

    public SpawnManager spawnManager;

    public GameObject unit;
    public Transform[] pos;
    public const int tileWidth = 5;
    public Tower[] towers;

    private void Awake()
    {
        Instance = this;
        towers = new Tower[pos.Length];
    }

    public void RemoveTower(Tower tower)
    {
        towers[tileWidth * tower.tilePosition.y + tower.tilePosition.x] = null;
        Destroy(tower.gameObject);
    }

    public Tower FindMergeTarget(Tower tower)
    {
        for(int i = 0; i < towers.Length; i++)
        {
            if (towers[i] != null && towers[i].data == tower.data && towers[i] != tower) return towers[i];
        }
        return null;
    }

    public bool IsTileMapFull()
    {
        for(int i = 0; i < towers.Length; i++)
        {
            if (towers[i] == null) return false; 
        }

        return true;
    }

    public bool IsTileEmpty(Vector2Int posInt)
    {
        return GetTower(posInt) == null;
    }

    public Tower GetTower(Vector2Int posInt)
    {
        return towers[tileWidth * posInt.y + posInt.x];
    }

    public Transform GetTile(Vector2Int posInt)
    {
        return pos[tileWidth * posInt.y + posInt.x];
    }

    public void AddTower(TowerData data, Vector2Int posInt)
    {
        GameObject gO = Instantiate(data.unit, GetTile(posInt).position, Quaternion.identity);
        Tower tower = gO.GetComponent<Tower>();
        tower.spawnManager = spawnManager;

        if(spawnManager.enemies[0] != null) tower.enemyObj = spawnManager.enemies[0].gameObject;
        tower.Init(data, posInt);
        towers[tileWidth * posInt.y + posInt.x] = tower;
    }
}
