using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public SpawnManager spawnManager;
    public GameObject bulletObj;
    public float curShotDelay;
    public float maxShotDelay;
    public GameObject enemyObj;

    public TowerData data;
    public Vector2Int tilePosition;

    private float doubleClickTimer;

    private void Update()
    {
        doubleClickTimer -= Time.deltaTime;
        Barrage();
    }

    private void Barrage()
    {
        Fire();
        Reload();
    }

    private void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;

        if (enemyObj == null)
            return;

        GameObject bullet = Instantiate(bulletObj, transform.position, Quaternion.identity);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        Vector3 dirVec = enemyObj.transform.position - transform.position;
        rigid.AddForce(dirVec.normalized * 20f, ForceMode2D.Impulse);

        curShotDelay = 0;
    }

    private void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    public void Init(TowerData data, Vector2Int pos)
    {
        this.data = data;
        tilePosition = pos;
    }

    public void Merge(Tower tower)
    {
        if (data.nextTowerData == null)
            return;

        TileManager.Instance.RemoveTower(this);
        TileManager.Instance.RemoveTower(tower);
        TileManager.Instance.AddTower(data.nextTowerData, tilePosition);
    }

    public void OnClick()
    {
        if(doubleClickTimer > 0)
        {
            var mergeTarget = TileManager.Instance.FindMergeTarget(this);

            if (mergeTarget == null)
                return;

            Merge(mergeTarget);
        }
        else
        {
            doubleClickTimer = 0.25f;
        }
    }
}
