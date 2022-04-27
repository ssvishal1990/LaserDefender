using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projecileSpeed = 10;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float firingRate = 0.2f;
    
    [SerializeField] Transform playerBodyTransform;

    public bool isFiring;
    Coroutine firingCoroutine;
    void Start()
    {
        
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
                                                playerBodyTransform.position, 
                                                playerBodyTransform.rotation);
            Destroy(projectile, 
                    projectileLifeTime);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if(rb != null){
                rb.velocity = transform.up * projecileSpeed;
            }

            yield return new WaitForSeconds(firingRate);
        }
    }
}
