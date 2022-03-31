using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSo : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;

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
