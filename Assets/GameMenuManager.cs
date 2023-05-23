using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private InputActionProperty _showButton;
    [SerializeField] private Transform head;
    [SerializeField] private float _spawnDistance = 2;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (_menu.activeSelf) Time.timeScale = 0f;
        if (!_menu.activeSelf) Time.timeScale = 1f;
        if (_showButton.action.WasPressedThisFrame())
        {
            _menu.SetActive(!_menu.activeSelf);
            _menu.transform.position = head.position +
                                       new Vector3(head.forward.x, 0, head.forward.z).normalized * _spawnDistance;
        }
        _menu.transform.LookAt(new Vector3(head.position.x, _menu.transform.position.y, head.position.z));
        _menu.transform.forward *= -1;
    }
}
