﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  [SerializeField] float mainThrust = 10f;
  [SerializeField] float rotateThrust = 10f;
  [SerializeField] AudioClip mainEngine;

  [SerializeField] ParticleSystem mainBooster;
  [SerializeField] ParticleSystem leftBooster;

  [SerializeField] ParticleSystem rightBooster;

  Rigidbody rb;
  AudioSource audioSource;
  

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    audioSource = GetComponent<AudioSource>();
  }


  void Update()
  {
    ProcessThrust();
    ProcessRotation();
  }

  void ProcessThrust()
  {
    
    if (Input.GetKey(KeyCode.Space))
    {
      StartThrusting();
    }
    else
    {
      StopThrust();
    }

  }

  void StopThrust()
  {
    audioSource.Stop();
    mainBooster.Stop();
  }

  void StartThrusting()
  {
    rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

    if (!audioSource.isPlaying)
    {
      audioSource.PlayOneShot(mainEngine);
    }
    if (!mainBooster.isPlaying)
    {
      mainBooster.Play();
    }
    
  }

  void ProcessRotation()
  {
    if (Input.GetKey(KeyCode.A))
    {
      ApplyRotation(rotateThrust);
      if(!rightBooster.isPlaying)
      {
      rightBooster.Play();
      }
    }
    else if (Input.GetKey(KeyCode.D))
    {
      ApplyRotation(-rotateThrust);
      if(!leftBooster.isPlaying)
      {
      leftBooster.Play();
      }
    }
    else
    {
      rightBooster.Stop();
      leftBooster.Stop();
    }
  }

  void ApplyRotation(float rotationThisFrame)
  {
    rb.freezeRotation = true;
    transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    rb.freezeRotation = false;
  }
}
