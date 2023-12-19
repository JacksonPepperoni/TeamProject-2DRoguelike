using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrap : Obstacle
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private int spawnCount;
    protected override void DestroySelf()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        }
        base.DestroySelf();
    }
}