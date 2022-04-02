using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float fireSpeed = 30f;

    private Rigidbody projectileRigidbody;

    private void Awake() {
        projectileRigidbody = GetComponent<Rigidbody>();
    }
    public void Fire(InputAction.CallbackContext context) {
        if (context.performed) {
            projectileRigidbody.AddRelativeForce(Vector3.down * fireSpeed, ForceMode.Impulse);
        }
    }

}
