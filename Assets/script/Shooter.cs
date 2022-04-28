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

    [SerializeField] bool isEnemy = false;
    


    public bool isFiring;
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

            yield return new WaitForSeconds(firingRate);
        }
    }
}
