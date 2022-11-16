using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 250f;
    private float _lookVecX, _lookVecY;

    public void Look(InputAction.CallbackContext context)
    {
        Vector2 lookVec = context.ReadValue<Vector2>();
        _lookVecX = Mathf.Clamp(_lookVecX, -5.0f, 80.0f);
        _lookVecY = Mathf.Clamp(_lookVecY, -5.0f, 80.0f);
        _lookVecX = lookVec.x * rotationSpeed * Time.deltaTime;
        _lookVecY = lookVec.y * rotationSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        Quaternion canTurnAngles = Quaternion.Euler(0, _lookVecX, _lookVecY);

        transform.Rotate(new Vector3(0, canTurnAngles.y * rotationSpeed * 100.0f * Time.deltaTime, 0));
    }
}

