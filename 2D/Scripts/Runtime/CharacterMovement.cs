using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bus
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        
        private Vector2 _move;

        public void OnMove(InputAction.CallbackContext context)
        {
            _move = context.ReadValue<Vector2>();
        }

        private void Update()
        {
            transform.Translate(_move * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
