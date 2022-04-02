using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cylinder : MonoBehaviour
{
    public float RotationAmount = 2f;
    public int TicksPerSecond = 60;
    public bool Pause = false;
    public Transform Target;
    public float Speed = 1f;
    private Coroutine LookCoroutine;

    // Start is called before the first frame update
    public void RotateUp(InputAction.CallbackContext context) {
        if (context.performed) {
            if (LookCoroutine != null) {
                StopCoroutine(LookCoroutine);
            }
            LookCoroutine = StartCoroutine(PitchUp());
        }
    }

    public void RotateDown(InputAction.CallbackContext context) {
        if (context.performed) {
            if (LookCoroutine != null) {
                StopCoroutine(LookCoroutine);
            }
            LookCoroutine = StartCoroutine(PitchDown());
        }
    }

    private IEnumerator PitchUp()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 2, 0);
        float time = 0;

        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, time);
            time += Time.deltaTime * Speed;

            yield return null;
        }
    }

    private IEnumerator PitchDown()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, -2, 0);
        float time = 0;

        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, time);
            time += Time.deltaTime * Speed;

            yield return null;
        }
    }
}

