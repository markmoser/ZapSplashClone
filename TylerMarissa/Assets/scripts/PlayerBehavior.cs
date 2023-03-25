using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    PlayerControls controls;

    //stored data from input
    Vector2 movement;

    void Awake()
    {
        controls = new PlayerControls();
        
        //moves player when stick is used, cancels movement when not
        controls.PlayerActions.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.PlayerActions.Move.canceled += ctx => movement = Vector2.zero; //(0,0)
    }

    void FixedUpdate()
    {
        //moves player by getting "movement" from input controls
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 5f * Time.deltaTime;
        transform.Translate(movementVelocity, Space.World);
    }


    void OnEnable()
    {
        controls.PlayerActions.Enable();
    }

    void OnDisable()
    {
        controls.PlayerActions.Disable();
    }
}
