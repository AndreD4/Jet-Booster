using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  [SerializeField] AudioClip crashAudio;
  [SerializeField] AudioClip landAudio;

  [SerializeField] ParticleSystem successParticles;
  [SerializeField] ParticleSystem crashParticles;

  [SerializeField] float delayCrash = 1f;
  [SerializeField] float delayNextLevel = 2f;

  AudioSource audioSource;

  bool isTransitioning = false;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }

  void OnCollisionEnter(Collision other)
  {
    if (isTransitioning){ return ;}
    
    switch (other.gameObject.tag)
    {
      case "Friendly":
          Debug.Log("this is friendly");
          break;
      case "Finish":
          StartSuccessSequence();
          break;
      case "Fuel":
          Debug.Log("you have fueled up");
          break;
      default:
         StartCrashSequence();
          break;
    } 
  }

  void StartSuccessSequence()
  {
    isTransitioning = true;
    audioSource.Stop();
    audioSource.PlayOneShot(landAudio);
    successParticles.Play();
    GetComponent<Movement>().enabled = false;
    Invoke("LoadNextLevel", delayNextLevel);
  }

  void StartCrashSequence()
  {
    isTransitioning = true;
    audioSource.Stop();
    audioSource.PlayOneShot(crashAudio);
    crashParticles.Play();
    GetComponent<Movement>().enabled = false;
    Invoke("ReLoadLevel", delayCrash);
  }

  void LoadNextLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex +1;
    if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
    {
      nextSceneIndex = 0;
    }
    SceneManager.LoadScene(nextSceneIndex);
  }

  void ReLoadLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }

  
}
