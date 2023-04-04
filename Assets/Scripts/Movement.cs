﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  [SerializeField] float mainThrust = 10f;
  [SerializeField] float rotateThrust = 10f;
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
      rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime );

      if(!audioSource.isPlaying)
      {
        audioSource.Play();
      }
      else
      {
        audioSource.Stop();
      }
    }

  }

  void ProcessRotation()
  {
    if (Input.GetKey(KeyCode.A))
    {
      ApplyRotation(rotateThrust);
    }
    else if (Input.GetKey(KeyCode.D))
    {
      ApplyRotation(-rotateThrust);
    }
  }

  void ApplyRotation(float rotationThisFrame)
  {
    rb.freezeRotation = true;
    transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    rb.freezeRotation = false;
  }
}
