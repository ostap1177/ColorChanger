using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;

    private Transform _transform;
    private Vector3 _minPositionPlayer;
    private Vector3 _maxPositionPlayer;

    private void Awake()
    {
        _transform = transform;
        _transform.position = new Vector3(0,_transform.position.y,_transform.position.z) ;
        _minPositionPlayer = new Vector3(_minPositionX, _transform.position.y, _transform.position.z);
        _maxPositionPlayer = new Vector3(_maxPositionX, _transform.position.y, _transform.position.z);
    }

    public void SetPosition(float position)
    {
        Move(position);
    }

    private void Move(float position)
    {
        _transform.position = Vector3.Lerp(_minPositionPlayer, _maxPositionPlayer, position);
    }
}
