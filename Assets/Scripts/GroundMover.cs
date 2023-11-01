using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundMover : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _finishPosition;
    [SerializeField] private float _speed;
    
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        if (_transform.position.z <= _finishPosition.position.z)
        {
            _transform.position = _startPosition.position;
        }
    }

    private void Move()
    {
        _transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }
}
