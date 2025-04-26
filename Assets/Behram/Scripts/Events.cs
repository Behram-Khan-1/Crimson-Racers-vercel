using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public GameObject player;
    // private float rotationAngle = 25f;

    private void Start()
    {
       
    }

    public void RightTurn()
    {
        Debug.Log("Right turn");
    player.transform.localRotation = Quaternion.Euler(0f, 0f, -50f);

    }
}

