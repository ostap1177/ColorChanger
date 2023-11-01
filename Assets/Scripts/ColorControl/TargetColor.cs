using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetColor : MonoBehaviour
{
    [SerializeField] private Material[] _materialsColor;
    [SerializeField] private MatchColor _colorMatch;
    [SerializeField] private int _timeDelayBlendColor;
    [SerializeField] private List<Renderer> _childsRenderer;

//    public event UnityAction<Color> TargetColorAssigned;
    public event UnityAction<Color,Color> ColorAssignedBlend;

    private int _targetNumberColorOne;
    private Color _colorOne;
    private int _targetNumberColorTwo;
    private Color _colorTwo;
    private Color _colorBlend;
    private Renderer _rendererNow;

    private Coroutine _delayToBlend;
    private WaitForSeconds _waitForSeconds;
    

    private void OnEnable()
    {
        _colorMatch.MatchedColor += OnColorAchieved;
        _colorMatch.PlayerColorRecrived += GaveTargetColor;
    }

    private void OnDisable()
    {
        _colorMatch.MatchedColor -= OnColorAchieved;
        _colorMatch.PlayerColorRecrived -= GaveTargetColor;
    }

    private void Start()
    {
        _rendererNow = GetComponent<Renderer>();
        _waitForSeconds = new WaitForSeconds(_timeDelayBlendColor);

        BlendColor();
    }

    private void GaveTargetColor()
    {
        _colorMatch.TransmitTargetColor(_colorBlend);
    }

    private void OnColorAchieved(bool match)
    {
        BlendColor();
    }

    private void BlendColor()
    {
        _targetNumberColorOne = Random.Range(0,_materialsColor.Length);
        _targetNumberColorTwo = Random.Range(0, _materialsColor.Length);

        if (_targetNumberColorOne == _targetNumberColorTwo)
        {
            while (_targetNumberColorOne == _targetNumberColorTwo)
            {
                _targetNumberColorTwo = Random.Range(0, _materialsColor.Length);
            }
        }

        _colorOne = _materialsColor[_targetNumberColorOne].color;
        _colorTwo = _materialsColor[_targetNumberColorTwo].color;
        _colorBlend = new Color (_colorOne.r + _colorTwo.r, _colorOne.g + _colorTwo.g, _colorOne.b + _colorTwo.b, 1);

        ColorAssignedBlend?.Invoke(_colorOne, _colorTwo);

        foreach (Renderer rendererChild in _childsRenderer )
        {
            foreach (Material material in rendererChild.materials)
            {
                material.color = _colorBlend;
            }
        }
    }
}
