using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;

    private Coroutine _delayTimeStop;
    private WaitForSeconds _waitForSeconds;
    private float _secondsDelay = 3f;

    private void OnEnable()
    {
        _player.PlayerDied += OnPlayerDied;

        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.PlayerDied -= OnPlayerDied;

        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    void Start()
    {
        Time.timeScale = 1;
        _gameOverPanel.SetActive(false);
        _waitForSeconds = new WaitForSeconds(_secondsDelay);
    }

    private void OnPlayerDied()
    {
        StopTime();

        _gameOverPanel.SetActive(true);
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void StopTime()
    {
        if (_delayTimeStop != null)
        {
            StopCoroutine(_delayTimeStop);
        }

        _delayTimeStop = StartCoroutine(DelayStopTime());
    }

    private IEnumerator DelayStopTime()
    {
        yield return _waitForSeconds;

        Time.timeScale = 0;
    }
}
