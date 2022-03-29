using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Projectile : MonoBehaviour
{

    private Rigidbody projectileRigidbody;

    private void Awake() {
        projectileRigidbody = GetComponent<Rigidbody>();
    }
    public void Fire(InputAction.CallbackContext context) {
        if (context.performed) {
            projectileRigidbody.AddRelativeForce(Vector3.up * 30f, ForceMode.Impulse);
        }
    }

    public void Rotate(InputAction.CallbackContext context) {
        if (context.performed) {
            projectileRigidbody.transform.Rotate(-275, -0, 0);
        }

    }
}
