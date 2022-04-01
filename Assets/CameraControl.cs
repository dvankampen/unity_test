using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Zoom(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        // if (Input.GetAxis("Mouse ScrollWheel") > 0) {
        //     camera.fieldOfView++;
        // } else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
        //     camera.fieldOfView--;
        // }
    }
}
