using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MatchColor : MonoBehaviour
{  
    public event UnityAction<bool> MatchedColor;

    public event UnityAction PlayerColorRecrived;

    private Color _playerColor;
    private Color _desiredColor;


    public void TransmitPlayerColor(Color color)
    {
        _playerColor = color;
        PlayerColorRecrived?.Invoke();
    }

    public void TransmitTargetColor(Color color)
    {
        _desiredColor = color;

        CheckMatch();
    }

    private void CheckMatch()
    {
        if (_playerColor == _desiredColor)
        {
            MatchedColor?.Invoke(true);
        }
    }
}
