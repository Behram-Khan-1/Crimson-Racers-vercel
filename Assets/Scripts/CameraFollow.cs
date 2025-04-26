using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform[] targets; 
    public Vector3 offset = new Vector3(0, 5, -10); 
    public float followSpeed = 5f; 

    [Header("Zoom Settings")]
    public float zoomSpeed = 2f;
    public float minZoom = 5f;
    public float maxZoom = 20f;
    private float currentZoom = 10f;

    [Header("Rotation Settings")]
    public float rotationSpeed = 100f;
    private float currentRotation = 0f;

    private void LateUpdate()
    {
        if (targets == null || targets.Length == 0) return;

        HandleZoom();
        HandleRotation();

        Vector3 centerPoint = GetCenterPoint();
        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0); 
        Vector3 desiredPosition = centerPoint + rotation * (offset.normalized * currentZoom);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.LookAt(centerPoint);
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= scroll * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    void HandleRotation()
    {
        if (Input.GetMouseButton(1)) 
        {
            float horizontal = Input.GetAxis("Mouse X");
            currentRotation += horizontal * rotationSpeed * Time.deltaTime;
        }
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Length == 1)
            return targets[0].position;

        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        foreach (Transform target in targets)
        {
            bounds.Encapsulate(target.position);
        }

        return bounds.center;
    }
}
