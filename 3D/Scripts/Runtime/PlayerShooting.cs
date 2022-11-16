using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        Ray ray = new Ray(transform.position, Camera.main.transform.forward * 100.0f);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.collider.name.Contains("Enemy"))
            {
                hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(10.0f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Camera.main.transform.forward * 100.0f);
    }
}

