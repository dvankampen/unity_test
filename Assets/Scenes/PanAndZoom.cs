using UnityEngine;
using Cinemachine;

public class PanAndZoom : MonoBehaviour
{
    [SerializeField]
    private float panSpeed = 2f;
    [SerializeField]
    private float zoomSpeed = 30f;
    [SerializeField]
    private float zoomInMax = 40f;
    [SerializeField]
    private float zoomOutMax = 90f;
    private CinemachineInputProvider inputProvider;
    private CinemachineVirtualCamera vcam;
    private Transform cameraTransform;

    private void Awake() {
        inputProvider = GetComponent<CinemachineInputProvider>();
        vcam = GetComponent<CinemachineVirtualCamera>();
        cameraTransform = vcam.VirtualCameraGameObject.transform;
    }
    void Start()
    {
        
    }

    void Update()
    {
        float x = inputProvider.GetAxisValue(0);
        float y = inputProvider.GetAxisValue(1);
        float z = inputProvider.GetAxisValue(2);
        if (x != 0 || y != 0) {
            PanScreen(x,y);
        }
        if (z != 0) {
            ZoomScreen(z);
        }
    }

    public void ZoomScreen(float increment)
    {
        Debug.Log("zoom screen called!");
        float fov = vcam.m_Lens.FieldOfView;
        float target = Mathf.Clamp(fov + increment, zoomInMax, zoomOutMax);
        vcam.m_Lens.FieldOfView = Mathf.Lerp(fov, target, zoomSpeed * Time.deltaTime);

    }

    public Vector2 PanDirection(float x, float y) {
        Vector2 direction = Vector2.zero;
        if (y >= Screen.height * .95) {
            direction.y += 1;
        }
        else if (y <= Screen.height * .05) {
            direction.y -= 1;
        }
        if (x >= Screen.width * .95) {
            direction.x += 1;
        }
        else if (x <= Screen.width * .05) {
            direction.x -= 1;
        }
        return direction;
    }

    public void PanScreen(float x, float y) {
        Vector2 direction = PanDirection(x, y);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, 
        cameraTransform.position + (Vector3)direction, Time.deltaTime* panSpeed);
    }
}
