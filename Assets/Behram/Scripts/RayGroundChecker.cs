using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RayGroundChecker : MonoBehaviour
{
    public float raycastHeight = 1.0f;
    public float raycastDistance = 5.0f;
    public float alignSpeed = 10f;
    public float rotationSpeed= 20f;
    public float yOffset = 0.02f;
    public LayerMask groundLayer;

    private Transform bikeRoot;

    void Start()
    {
        bikeRoot = this.transform; // could be replaced with another reference if needed
    }

    void Update()
    {
        SnapToGround();
    }

    void SnapToGround()
    {
        Vector3 rayOrigin = bikeRoot.position + Vector3.up * raycastHeight;
        Ray ray = new Ray(rayOrigin, Vector3.down);
        RaycastHit hit;

        Debug.DrawRay(rayOrigin, Vector3.down * raycastDistance, Color.red);

        if (Physics.Raycast(ray, out hit, raycastDistance, groundLayer))
        {
            // Debug.Log(hit.point + " hit " + hit.distance);
             Vector3 adjustedPosition = transform.position;
            adjustedPosition.y = hit.point.y + yOffset;
            transform.position = adjustedPosition;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;


            // Vector3 slopeNormal = hit.normal;
            // Vector3 slopeForward = Vector3.ProjectOnPlane(transform.forward, slopeNormal).normalized;
            // // Calculate target rotation based on slope
            // Quaternion targetRotation = Quaternion.LookRotation(slopeForward, slopeNormal);

            // // Smoothly rotate to match slope
            // transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            // Debug.DrawLine(hit.point, hit.point + slopeForward, Color.green, 5f);

        }
    }
}
