using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Properties and Fields

    private const int IsMovingParameterId = 120489994;

    [SerializeField] private float movementSpeed = 3;
    [SerializeField] private float rotationSpeed = 10;
    PlayerControls playerControls;


    private InputAction movement;


    #endregion

    private void Awake()
    {
        playerControls = new PlayerControls();

        movement = playerControls.Gameplay.Movement;

        movement.performed += OnMovementPerfomed;
        movement.canceled += OnMovementPerfomed;


    }

    private void OnMovementPerfomed(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();

        Direction = new Vector3(direction.x, 0, direction.y);
    }

    private void OnDisable()
    {

        movement.Disable();
    }
    private void OnEnable()
    {

        movement.Enable();
    }

    private void FixedUpdate()
    {

        if (!IsMoving) return;

        transform.position += Direction * movementSpeed * Time.deltaTime;
        transform.rotation = Rotation;


    }



    #region Movement Properties

    private bool IsMoving => Direction != Vector3.zero;
    private Vector3 Direction { get; set; }
    private Quaternion Rotation => Quaternion.LookRotation(RotationDirection);

    private Vector3 RotationDirection =>
        Vector3.RotateTowards(
            transform.forward,
            Direction,
            rotationSpeed * Time.deltaTime,
            0);

    #endregion
}
