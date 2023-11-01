using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private int _countBlandColor;
    [SerializeField] private int _timeDelayResetColor;
    [SerializeField] private MatchColor _colorMatch;
    [SerializeField] private Material _materialChang;
    [SerializeField] private Material _materialStart;
    [SerializeField] private int _countBlinks;
    [SerializeField] private float _secondsBetweenBlink;


    private WaitForSeconds _waitForSeconds;
    private WaitForSeconds _waitForSecondsBlinks;
    private Coroutine _delayResetColor;
    private Coroutine _delayBlinkTakingDamage;
    private Color _blinkColor;
    private Color _colorAdd;
    private int _countCollision = 0;
    private bool _isResetColor;

    private void OnEnable()
    {
        _colorMatch.MatchedColor += OnMatchedColor;
    }

    private void OnDisable()
    {
        _colorMatch.MatchedColor -=OnMatchedColor;
    }

    private void Start()
    {
        _materialChang.color = _materialStart.color;
        _waitForSeconds = new WaitForSeconds(_timeDelayResetColor);
        _waitForSeconds = new WaitForSeconds(_secondsBetweenBlink);
        _blinkColor = new Color(0,0,0,0);
    }

    private void Update()
    {
        if(_countCollision == _countBlandColor)
        {
            _countCollision = 0;
           
            ResetColor();
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent<Barrier>(out Barrier barrier) == true &&
            trigger.TryGetComponent<Renderer>(out Renderer renderTrigger) == true &&
           _isResetColor == false)
        {
            if (barrier.Damge == 0)
            {
                if (_countCollision == 0)
                {
                    _materialChang.color = renderTrigger.material.color;
                    _countCollision++;
                }
                else
                {
                    _colorAdd = new Color(renderTrigger.material.color.r, renderTrigger.material.color.g, renderTrigger.material.color.b, 0);
                    _materialChang.color += _colorAdd;
                    _countCollision++;

                    _colorMatch.TransmitPlayerColor(_materialChang.color);
                }
            }
            else
            {
                BlinkTakingDamage();
            }
        }
    }

    private void OnMatchedColor(bool math)
    {
        if (math == true)
        {
            ResetColor();
        }
    }

    private void ResetColor()
    {
        if(_delayResetColor != null)
        {
            StopCoroutine(_delayResetColor);
        }

        _delayResetColor =StartCoroutine(DelaayResetColor());
    }

    private IEnumerator DelaayResetColor()
    {
        _isResetColor = true;

        yield return _waitForSeconds;

        _isResetColor = false;
        _materialChang.color = _materialStart.color;
    }

    private void BlinkTakingDamage()
    {
        if (_delayBlinkTakingDamage != null)
        {
            StopCoroutine(_delayBlinkTakingDamage);
        }

        _delayBlinkTakingDamage = StartCoroutine(DelayBlink());
    }

    private IEnumerator DelayBlink()
    {
        _isResetColor = true;

        for (int i = 0; i < _countBlinks; i++)
        {
            _materialChang.color = _blinkColor; 

            yield return _waitForSecondsBlinks;

            _materialChang.color = _materialStart.color;
        }

        _countCollision = 0;
        _isResetColor = false;
    }
}
