using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSo> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0.2f;
    [SerializeField] private bool isLooping = true;
    WaveConfigSo currentWave;

    
    void Start()
    {
        currentWave = waveConfigs[0];
        StartCoroutine(spawnEnemy());
        
    }

    public WaveConfigSo getCurrentWave(){
        return currentWave;
    }

    IEnumerator spawnEnemy()
    {
        do{
            foreach(WaveConfigSo  config in waveConfigs){
                currentWave = config;
                for(int i = 0; i < currentWave.getEnemyCount() ;i++ ){
                    GameObject newEnemy =  Instantiate(currentWave.getEnemyPrefab(0), 
                                currentWave.GetStartingWayPoint().position, 
                                Quaternion.identity, gameObject.transform);
                    newEnemy.tag = "Enemy";
                    yield return new WaitForSeconds(currentWave.getRandomSpawnTime());
                }
                yield return new WaitForSecondsRealtime(timeBetweenWaves);
            }
        }while(isLooping); 
    }


}


///UIGDSOFSYHHFHDASUJDHDJ
