using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] WaveConfigSo waveConfig;
    List<Transform> waypoints;
    int waypointsIdx = 0;
    
    void Start()
    {
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointsIdx].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if(waypointsIdx < waypoints.Count){
            Vector3 targetPosition = waypoints[waypointsIdx].position;
            float delta = waveConfig.getMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition){
                waypointsIdx++;
            }
        }else{
            Destroy(gameObject);
        }
    }
}
