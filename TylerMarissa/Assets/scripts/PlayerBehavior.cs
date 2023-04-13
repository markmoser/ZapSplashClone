using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    private float movementSpeed = 5f;
    private Vector2 movement;
    private Vector2 playerMovement;
    //[SerializeField] private Transform orientation;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private Rigidbody2D rb2D;

    private InputActionAsset inputAsset;
    private InputActionMap inputMap;
    private InputAction move, interact, attack, resetLevel;

    private DoorBehavior doorScript;
    private ButtonBehavior buttonScript;

    private bool inDoorRange, touchingButton;
    public bool stunned;

    [SerializeField] private GameObject playerAmmo;
    public float ammoSpeed;
    [SerializeField] private GameObject ammoSpawn;

    public bool IsElePlayer;

    private void Start()
    {
        inDoorRange = false;
        touchingButton = false;
        stunned = false;
    }
    void Awake()
    {
        //assigns input assets and actions to references
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        move = inputMap.FindAction("Move");
        interact = inputMap.FindAction("Interact");
        attack = inputMap.FindAction("Attack");
        resetLevel = inputMap.FindAction("ResetLevel");

        //sets the movement velocity for the players
        move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        move.canceled += ctx => movement = Vector2.zero; //(0,0)

        //allows you to interact with objects you are in rage of
        interact.performed += ctx => Interact();

        //players attack function
        attack.performed += ctx => Attack();

        //reset level
        resetLevel.performed += ctx => ResetLevel();

    }

    public void MovePlayer(Vector2 targetLoc)
    {
        transform.position = targetLoc;
    }

    void FixedUpdate()
    {
        if(!stunned)
        {
            //movement
            Vector2 movementVelocity = new Vector2(movement.x, movement.y) * movementSpeed * Time.deltaTime;
            transform.Translate(movementVelocity, Space.Self);

            //rotation of the player during movement
            //orientation.Rotate(movement.x, movement.y, 0);
            //playerMovement = rb2D.velocity;
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, movement);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb2D.MoveRotation(rotation);
        }
    }

    public void Interact()
    {
        if (inDoorRange)
        {
            doorScript.GoThroughDoor(gameObject);
        }
        if (touchingButton)
        {
            buttonScript.PressButton();
        }
    }

    private void Attack()
    {
        Instantiate(playerAmmo, ammoSpawn.transform.position, transform.rotation);
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(0);
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
