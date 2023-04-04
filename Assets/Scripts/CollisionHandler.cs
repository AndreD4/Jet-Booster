﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
      default:
          ReLoadLevel();
          Debug.Log("you blew up");
          break;

    } 
  }

  void ReLoadLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }
}
