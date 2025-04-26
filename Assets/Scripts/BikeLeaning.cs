using UnityEngine;

public class BikeLeaning : MonoBehaviour
{
    public float leanAngle = 30f; // How much the bike leans
    public float leanSpeed = 5f;  // How fast the bike leans and straightens

    private float currentLean = 0f;

    void Update()
    {
        float turnInput = Input.GetAxis("Horizontal"); // A/D keys or Arrow keys
        float targetLean = turnInput * leanAngle;

        // Smoothly interpolate between current lean and target lean
        currentLean = Mathf.Lerp(currentLean, targetLean, Time.deltaTime * leanSpeed);

        // Apply the lean (rotation around Z-axis)
        transform.localRotation = Quaternion.Euler(0f, transform.localRotation.eulerAngles.y, -currentLean);
    }
}

