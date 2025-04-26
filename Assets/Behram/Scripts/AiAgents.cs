using UnityEngine;
using UnityEngine.AI;

public class AiAgents : MonoBehaviour
{
    public int bikeId = 0; // Unique ID per bike
    public Transform[] waypoints; // Assign this bike's waypoint path
    private Transform[] _ChildWaypoints; // Assign this bike's waypoint path
    public float reachThreshold = 1.5f; // Close enough to consider reached

    public int currentIndex = 0;
    public NavMeshAgent agent;
    System.Random rng;
    private int seedValue;

    public int GetSeedFromString(string input)
    {
        // RaceResult apiResponse = GameManager.Instance.GetApiResponse();
        seedValue = 0;
        foreach (char c in input)
        {
            seedValue = (seedValue * 31) + c;
        }
        Debug.Log("seedValue" + seedValue);
        return seedValue;
    }


    private async void Start()
    {
        RaceResult apiResponse = await GameManager.Instance.GetApiResponseAsync();
        rng = new System.Random(GetSeedFromString(apiResponse.rid) + bikeId);
    
        if (waypoints.Length > 0)
        {
            Transform firstTarget = GetPointFromWaypoint(waypoints[0], bikeId);
            if (firstTarget != null)
            {
                agent.SetDestination(firstTarget.position);
            }
        }
            // if (waypoints.Length > 0)
            // {
            //     agent.SetDestination(waypoints[currentIndex].position);
            // }
    }
    Transform GetPointFromWaypoint(Transform waypoint, int childIndex)
    {
        if (waypoint.childCount > childIndex)
        {
            return waypoint.GetChild(childIndex);
        }
        return null;
    }
    private void Update()
    {
        // Optional backup: if bike reaches target by itself
        if (agent.remainingDistance > 0 && agent.remainingDistance <= reachThreshold)
        {
            GoToNextWaypoint();
        }
    }

    public void GoToNextWaypoint()
    {
        currentIndex++;
        // Debug.Log($"Bike {bikeId} reached waypoint {currentIndex}");
        if (currentIndex < waypoints.Length)
        {
            int randomIndex = rng.Next(0, waypoints[currentIndex].childCount);
            Transform target = GetPointFromWaypoint(waypoints[currentIndex], randomIndex);
            // Debug.Log( gameObject.name  + " going to "+ target.name);
            if (target != null)
            {
                agent.SetDestination(target.position);
            }
            // agent.SetDestination(waypoints[currentIndex].position);
        }
        else
        {
            agent.isStopped = true;
            Debug.Log($"Bike {bikeId} finished race.");
        }
    }


}
