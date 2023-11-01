using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnPlayGame);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnPlayGame);
    }

    void Start()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnPlayGame()
    {
        _gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
