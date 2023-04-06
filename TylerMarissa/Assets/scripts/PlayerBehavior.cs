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
    InputAction move;

    public bool stunned;

    private void Start()
    {
        stunned = false;
    }

    void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        move = inputMap.FindAction("Move");

        move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        move.canceled += ctx => movement = Vector2.zero; //(0,0)
    }
    void FixedUpdate()
    {
        if(!stunned)
        {
            Vector2 movementVelocity = new Vector2(movement.x, movement.y) * movementSpeed * Time.deltaTime;
            transform.Translate(movementVelocity, Space.Self);
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
