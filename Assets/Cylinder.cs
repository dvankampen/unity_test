using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cylinder : MonoBehaviour
{
    // Start is called before the first frame update
    public void Rotate(InputAction.CallbackContext context) {
        Debug.Log("Cylinder rotating!!");
        if (context.performed) {
            transform.Rotate(0, 5, 0);
        }


    }
}
