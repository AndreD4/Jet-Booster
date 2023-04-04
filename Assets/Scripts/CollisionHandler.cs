using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
  void OnCollisionEnter(Collision other)
  {
    switch (other.gameObject.tag)
    {
      case "Friendly":
          Debug.Log("this is friendly");
          break;
      case "Finish":
          Debug.Log("you have landed");
          break;
      case "Fuel":
          Debug.Log("you have fueled up");
          break;
      case "Default":
          Debug.Log("you blew up");
          break;

    }
  }
}
