using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData data;
    public Vector2Int tilePosition;

    private float doubleClickTimer;

    private void Update()
    {
        doubleClickTimer -= Time.deltaTime;
    }

    public void Init(TowerData data, Vector2Int pos)
    {
        this.data = data;
        this.tilePosition = pos;
    }

    public void Merge(Tower tower)
    {
        Init(data.nextTowerData, tilePosition);
    }

    public void OnClick()
    {
        if(doubleClickTimer > 0)
        {
            Debug.Log("doubleClick");
        }
        else
        {
            doubleClickTimer = 0.25f;
        }
    }
}
