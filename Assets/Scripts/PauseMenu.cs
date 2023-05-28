using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    [SerializeField] private Transform _head;
    [SerializeField] private float _spawnDistance = 2;
    [SerializeField] private InputActionProperty _showButton;
    
    void Update()
    {
        if (_showButton.action.WasPressedThisFrame())
        {
            if (pauseMenuUI.activeSelf)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
            }
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
            pauseMenuUI.transform.position = _head.position +
                                       new Vector3(_head.forward.x, 0, _head.forward.z).normalized * _spawnDistance;
        }
        pauseMenuUI.transform. LookAt(new Vector3(_head.position.x, pauseMenuUI.transform.position.y, _head.position.z));
        pauseMenuUI.transform.forward *= -1;
    }
    
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading menu");
    }
}
