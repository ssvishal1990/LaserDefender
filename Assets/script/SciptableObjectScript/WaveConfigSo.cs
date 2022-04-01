using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSo : ScriptableObject
{
    [Header("Enemy basic properties")]
    [SerializeField] Transform pathPrefab;
    [SerializeField] List<GameObject> enemyPrefabList;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawner =  1f;
    [SerializeField] float spawnTimeVariance;

    public int getEnemyCount(){
        return enemyPrefabList.Count;
    }

    public GameObject getEnemyPrefab(int index){
        return enemyPrefabList[index];
    }
    public Transform GetStartingWayPoint(){
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints(){
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform childPaths in pathPrefab){
            waypoints.Add(childPaths);
        }
        return waypoints;
    }

    public float getMoveSpeed(){
        return moveSpeed;
    }
}
