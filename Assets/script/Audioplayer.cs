using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioplayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume;


    [Header("Taking Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageClipVolume;

    public void playShootingClip(){
        playClip(shootingClip, shootingVolume);
    }

    public void playDamageTakenClip(){
        playClip(damageClip, damageClipVolume);
    }

    public void playClip(AudioClip clip, float volume){
        if(clip == null){
            return;
        }

        Vector3 cameraPosition = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
    }
}
