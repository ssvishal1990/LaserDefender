using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int health = 50;
    DamageDealer damageDealer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null){
            takeDamage(damageDealer.getDamage());
            damageDealer.Hit();
        }
    }

    private void takeDamage(int Damage)
    {        
        if(health - Damage > 0){
            health -= Damage;
        }else{
            Destroy(gameObject);
        }
    }
}
