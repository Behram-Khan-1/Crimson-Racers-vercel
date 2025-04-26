using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Tilt : MonoBehaviour
{
    public Transform bikeModel; // The visual model of the bike
    private NavMeshAgent agent;
    public float leanAngle = 25f; // Max lean angle in degrees
    public float leanSpeed = 5f;  // How fast the bike leans
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        LeanIntoTurn();
    }
    void LeanIntoTurn()
    {
        if (agent.velocity.sqrMagnitude > 0.1f)
        {
            Vector3 localVelocity = transform.InverseTransformDirection(agent.velocity);
            float turnAmount = Mathf.Clamp(localVelocity.x, -1f, 1f); // X is side direction
            float targetLean = turnAmount * leanAngle;
            // Smoothly rotate bike model on Z-axis
            Quaternion targetRotation = Quaternion.Euler(0f, bikeModel.localEulerAngles.y, targetLean);
            bikeModel.localRotation = Quaternion.Lerp(bikeModel.localRotation, targetRotation, Time.deltaTime * leanSpeed);
        }
    }

}
