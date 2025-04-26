using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIBikeController : MonoBehaviour
{
    public Transform[] waypoints;
    public GameObject startButton;
    public GameObject replayButton;
    public Transform bikeModel; // The visual model of the bike

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private bool hasStarted = false;
    private bool reachedEnd = false;

    public float leanAngle = 25f; 
    public float leanSpeed = 5f;  

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;

        if (startButton != null) startButton.SetActive(true);
        if (replayButton != null) replayButton.SetActive(false);
    }

    void Update()
    {
        if (!hasStarted || reachedEnd) return;

        if (!agent.pathPending && agent.remainingDistance < 1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                agent.isStopped = true;
                reachedEnd = true;
                bikeModel.GetComponent<Rigidbody>().isKinematic = true;
                if (replayButton != null) replayButton.SetActive(true);
            }
            else
            {
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }

        LeanIntoTurn();
    }

    void LeanIntoTurn()
    {
        if (agent.velocity.sqrMagnitude > 0.1f)
        {
            Vector3 localVelocity = transform.InverseTransformDirection(agent.velocity);
            float turnAmount = Mathf.Clamp(localVelocity.x, -1f, 1f); 
            float targetLean = -turnAmount * leanAngle;

            
            Quaternion targetRotation = Quaternion.Euler(0f, bikeModel.localEulerAngles.y, targetLean);
            bikeModel.localRotation = Quaternion.Lerp(bikeModel.localRotation, targetRotation, Time.deltaTime * leanSpeed);
        }
    }

    public void StartRace()
    {
        if (waypoints.Length > 0)
        {
            hasStarted = true;
            agent.isStopped = false;
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }

        if (startButton != null) startButton.SetActive(false);
    }

    public void ReplayScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
