using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 7.0f;
    [SerializeField] private float runSpeed = 12.0f;
    [SerializeField] private Camera playerCamera;

    private float _horizontalMove, _verticalMove;
    private Vector3 _movement;

    private float _speed = 0.0f;

    private void Start()
    {
        _speed = walkSpeed;
    }

    public void Run(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _speed = runSpeed; 
            Debug.Log("Running");
        }
        else
        {
            _speed = walkSpeed;
            Debug.Log("Walking");
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 pos = context.ReadValue<Vector2>();
        _horizontalMove = pos.x * _speed;
        _verticalMove = pos.y * _speed;
    }

    private void Update()
    {
        _movement = new Vector3(-_horizontalMove, 0, 0) + (_verticalMove * playerCamera.transform.forward);

        transform.Translate(_movement * Time.deltaTime);
    }
}

