using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AiAgents mover = other.GetComponent<AiAgents>();
        if (mover != null)
        {
            Debug.Log($"Bike {mover.bikeId} hit trigger, going to next waypoint");
            mover.GoToNextWaypoint();
        }
    }
}