using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSo currentWave;
    void Start()
    {
        spawnEnemy();
    }

    public WaveConfigSo getCurrentWave(){
        return currentWave;
    }

    private  void spawnEnemy()
    {
        for(int i = 0; i < currentWave.getEnemyCount() ;i++ ){

        }
        Instantiate(currentWave.getEnemyPrefab(0), 
                    currentWave.GetStartingWayPoint().position, 
                    Quaternion.identity, gameObject.transform);
    }


}
