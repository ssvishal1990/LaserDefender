using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;

    void Awake(){
        material = GetComponent<SpriteRenderer>().material;
    }
    void Update(){
        Debug.Log("Modifying offset");
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;

    }
}
