using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    float movementSpeed = 5f;
    Vector2 movement;

    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction move,interact;
    private bool inDoorRange;
    public bool stunned;

    private void Start()
    {
        inDoorRange = false;
        stunned = false;
    }
    void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        move = inputMap.FindAction("Move");
        interact = inputMap.FindAction("Interact");

        //sets the movement velocity for the players
        move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        move.canceled += ctx => movement = Vector2.zero; //(0,0)

        interact.performed += ctx => EnterDoor();

    }
    private void EnterDoor()
    {
        
        if (inDoorRange) {
            print(inDoorRange);
            transform.position = new Vector2(-7, 0);
        }
    }
    void FixedUpdate()
    {
        if(!stunned)
        {
            Vector2 movementVelocity = new Vector2(movement.x, movement.y) * movementSpeed * Time.deltaTime;
            transform.Translate(movementVelocity, Space.Self);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            inDoorRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            inDoorRange = false;
        }
    }
    void OnEnable()
    {
        inputMap.Enable();
    }

    void OnDisable()
    {
        inputMap.Disable();
    }
}
