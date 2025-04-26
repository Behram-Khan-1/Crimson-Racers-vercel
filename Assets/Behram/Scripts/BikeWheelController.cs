using UnityEngine;

public class BikeWheelController : MonoBehaviour
{
    [System.Serializable]
    public class Wheel
    {
        public WheelCollider collider;
        public Transform visual;
    }

    // public Wheel frontWheel;
    public Wheel rearWheel;

    void Update()
    {
        // UpdateWheelPose(frontWheel);
        UpdateWheelPose(rearWheel);
    }

    void UpdateWheelPose(Wheel wheel)
    {
        Vector3 pos;
        Quaternion rot;

        wheel.collider.GetWorldPose(out pos, out rot);

        wheel.visual.position = pos;
        wheel.visual.rotation = rot;
    }
}
