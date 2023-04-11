using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    private float movementSpeed = 5f;
    private Vector2 movement;
    private DoorBehavior doorScript;
    private ButtonBehavior buttonScript;
    private InputActionAsset inputAsset;
    private InputActionMap inputMap;
    private InputAction move,interact;
    private bool inDoorRange, touchingButton;
    public bool stunned;

    private void Start()
    {
        inDoorRange = false;
        touchingButton = false;
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
        //allows you to interact with objects you are in rage of
        interact.performed += ctx => Interact();

    }

    public void MovePlayer(Vector2 targetLoc)
    {
        transform.position = targetLoc;
    }
    public void Interact()
    {
        if (inDoorRange) {
            doorScript.GoThroughDoor(gameObject);
        }
        if (touchingButton)
        {
            buttonScript.PressButton();
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
            doorScript = collision.gameObject.GetComponent<DoorBehavior>();
        }
        if (collision.gameObject.tag == "Button")
        {
            touchingButton = true;
            buttonScript = collision.gameObject.GetComponent<ButtonBehavior>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            inDoorRange = false;
        }
        if (collision.gameObject.tag == "Button")
        {
            touchingButton = false;
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
