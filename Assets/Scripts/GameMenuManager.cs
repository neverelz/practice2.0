using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private InputActionProperty _showButton;
    [SerializeField] private Transform _head;
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
            _menu.transform.position = _head.position +
                                       new Vector3(_head.forward.x, 0, _head.forward.z).normalized * _spawnDistance;
        }
        _menu.transform. LookAt(new Vector3(_head.position.x, _menu.transform.position.y, _head.position.z));
        _menu.transform.forward *= -1;
    }
}
