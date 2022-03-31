using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("movement speed")]
    [SerializeField] private float speed = 5;


    [Header("Padding Values")]
    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;

    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    void Start()
    {
        initBounds();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }


    void initBounds(){
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    private void move()
    {
        Vector3 delta = rawInput * speed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x , minBounds.x + paddingLeft , maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y , minBounds.y + paddingBottom , maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    public void moveEvent(InputAction.CallbackContext context){
        rawInput =  context.ReadValue<Vector2>();
    }
}
