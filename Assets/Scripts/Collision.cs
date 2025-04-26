using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
   void OnCollisionEnter(Collider other)    
   {
    Debug.Log("" + other.gameObject.name);
   }
}
