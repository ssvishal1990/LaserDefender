using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    DamageDealer damageDealer;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    Audioplayer audioplayer;


    void Awake(){
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioplayer = FindObjectOfType<Audioplayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null){
            takeDamage(damageDealer.getDamage());
            playHitEffect();
            ShakeCamera();
            onDamageSound();
            damageDealer.Hit();
        }
    }

    private void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake){
            cameraShake.Play();
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
    
    void playHitEffect(){
        if(hitEffect != null){
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void onDamageSound(){
        if(gameObject.tag == "Player"){
            audioplayer.playDamageTakenClip();
        }
    }
    

}
