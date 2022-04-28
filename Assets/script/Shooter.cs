using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projecileSpeed = 10;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;
    
    [Tooltip("Enemy firing rate settings")]
    [Header("Enemy Settings, AI")]
    [SerializeField] bool isEnemy = false;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
    void Start()
    {
        if(isEnemy){
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if(isFiring && firingCoroutine == null){
            firingCoroutine = StartCoroutine(fireContinously());
            Debug.Log("Couroutine should've started");
        }else if(!isFiring && firingCoroutine != null){
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }

    IEnumerator fireContinously()
    {
        while(true){

            GameObject projectile = Instantiate(projectilePrefab, 
                                                gameObject.transform.position, 
                                                gameObject.transform.rotation);
            Destroy(projectile, 
                    projectileLifeTime);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if(rb != null){
                if(isEnemy){
                    rb.velocity = -1* transform.up  * projecileSpeed;    
                }else{
                    rb.velocity = transform.up * projecileSpeed;
                }
            }

            float timeToNextProjectile = UnityEngine.Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
