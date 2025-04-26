using UnityEngine;

public class DynamicRaceCamera : MonoBehaviour
{
    public Transform[] targets;      // Assign your 6 bikes here
    public Vector3 offset;           // Offset from center point
    public float smoothTime = 0.5f;  // How smooth the camera moves
    public float minZoom = 40f;       // Zoom when bikes are close
    public float maxZoom = 10f;       // Zoom when bikes are far apart
    public float zoomLimiter = 50f;   // Higher = slower zoom out

    private Vector3 velocity;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main; // Or manually assign your camera
    }

    private void LateUpdate()
    {
        if (targets.Length == 0)
            return;

        Move();
        Zoom();
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom()
    {
        float greatestDistance = GetGreatestDistance();
        float newZoom = Mathf.Lerp(maxZoom, minZoom, greatestDistance / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Length; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Length == 1)
            return targets[0].position;

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Length; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}

