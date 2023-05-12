using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (gameObject.name == "Trigger1")
            {
                _gameObject.transform.position = new Vector3(3.17f, 0, 12.74f);
                _gameObject.transform.rotation = new Quaternion(-0.300304115f,0.915402412f,0.0518756397f,-0.262992233f);
            }

            if (gameObject.name == "Trigger2")
            {
                _gameObject.transform.position = new Vector3(12.69f,0,3.07f);
                _gameObject.transform.rotation = new Quaternion(0.282406986f,0.857821345f,-0.160994112f,-0.398082495f);
            }
        }
    }
}
