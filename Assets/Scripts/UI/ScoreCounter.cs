using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private MatchColor _colorMatch;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _bestScoreTextGameOver;
    [SerializeField] private int _matchPoint;

    private int _score = 0;
    private int _bestScore = 0;
    private string _nameBestScore = "BestScore";

    private void OnEnable()
    {
        _colorMatch.MatchedColor += OnAddPoints;
        _player.PlayerDied += OnPolayerDaied;
    }

    private void OnDisable()
    {
        _colorMatch.MatchedColor -= OnAddPoints;
        _player.PlayerDied += OnPolayerDaied;
    }

    private void Start()
    {
        _scoreText.text = _score.ToString();
        _bestScore = PlayerPrefs.GetInt(_nameBestScore, _bestScore);
    }

    private void OnAddPoints(bool isMatch)
    {
        if (isMatch == true)
        {
            _score += _matchPoint;
            _scoreText.text = _score.ToString();
        }
    }

    private void OnPolayerDaied()
    {
        if (_bestScore < _score)
        {
            _bestScore = _score;
            PlayerPrefs.SetInt(_nameBestScore,_bestScore);
        }

        _bestScoreTextGameOver.text = PlayerPrefs.GetInt(_nameBestScore, _bestScore).ToString();
    }
}
