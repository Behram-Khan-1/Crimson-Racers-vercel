// using System.Collections.Generic;
// using UnityEngine;

// public class WaypointManager : MonoBehaviour
// {
//     public AiAgents[] bikes;
//     public List<GameObject> _WayPoints;
//     private List<Transform> waypoints;

//     private void Start()
//     {
//         for (int i = 0; i < bikes.Length; i++)
//         {
//             var bike = bikes[i];
//             List<Transform> assignedPath = new List<Transform>();

//             for (int wpIndex = 0; wpIndex < _WayPoints.Count; wpIndex++)
//             {
//                 Transform wpParent = _WayPoints[wpIndex].transform;

//                 if (wpIndex == 0)
//                 {
//                     // First waypoint: assign by index
//                     assignedPath.Add(wpParent.GetChild(i));
//                 }
//                 else
//                 {
//                     // Next waypoints: assign randomly
//                     int randomIndex = Random.Range(0, wpParent.childCount);
//                     assignedPath.Add(wpParent.GetChild(randomIndex));
//                 }
//             }

//             bike.AssignPath(assignedPath.ToArray());
//         }
//     }


// }

