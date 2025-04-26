// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class GameManager : MonoBehaviour
// {
//     [SerializeField] float speed1 = 5f;
//     [SerializeField] float speed2 = 10f;
//     public static GameManager instance;
//     public Transform cube1;
//     public Transform cube2;

//     public List<Transform> waypointsAgent1 = new List<Transform>();
//     public List<Transform> waypointsAgent2 = new List<Transform>();

//     public Transform startPoint1;
//     public Transform startPoint2;
//     public Transform endPoint;

//     public Button replayButton;

//     public int winnerId = 1; // 1 or 2 (manual control)
//     private float raceDuration = 10f;
//     private float loserDelay = 2f;
//     private int seed = 42;
//     private Vector3 endPos;

//     void Awake()
//     {
//         instance = this;
//     }


//     void Start()
//     {
  
//         endPos = endPoint.position;

//         replayButton.onClick.AddListener(ReplayRace);

//         StartRace();
//     }

//     public void StartRace()
//     {
//         Random.InitState(seed);
//         // Reset positions
//         cube1.position = startPoint1.position;
//         cube2.position = startPoint2.position;

//          if (winnerId == 1)
//         {
//             cube1.GetComponent<AiAgents>().speed = speed1;
//             cube2.GetComponent<AiAgents>().speed = speed2;
//         }
//         else
//         {
//             cube1.GetComponent<AiAgents>().speed = speed2;
//             cube2.GetComponent<AiAgents>().speed = speed1;
//         }

//     }


//     public void ReplayRace()
//     {
//         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//     }
// }
