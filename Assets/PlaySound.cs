using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
   [SerializeField] private AudioSource _source;
   private Vector3 _startPosition;

   private void Start()
   {
      _startPosition = gameObject.transform.position;
   }

   private void Update()
   {
      if (gameObject.transform.position != _startPosition) _source.
   }
}
