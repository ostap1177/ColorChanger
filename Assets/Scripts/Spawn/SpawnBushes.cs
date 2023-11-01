using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBushes : MonoBehaviour
{
    [SerializeField] private GameObject[] _bushes;
    [SerializeField] private GroundMover _groundMover;
    [SerializeField] private int _countBushes;
    [SerializeField] private Transform _frontBoundtTransform;
    [SerializeField] private Transform _backBoundtTransform;
    [SerializeField] private Transform _leftBoundtTransform;
    [SerializeField] private Transform _rightBoundtTransform;

    private Transform _transform;
    private List<GameObject> _bushesInGame = new List<GameObject>();

    private void OnEnable()
    {
        //_groundMover.ReachedPosition += OnResetPosition;
    }

    private void OnDisable()
    {
       // _groundMover.ReachedPosition -= OnResetPosition;
    }

    private void Start()
    {
        int index = 0;
        _transform = transform;

        for (int i = 0; i < _countBushes; i++)
        {
            if (index == _bushes.Length)
            {
                index = 0;
            }

           GameObject bush = Instantiate(_bushes[index], SetPosition(), Quaternion.identity, _transform);
            _bushesInGame.Add(bush);
            index++;

        }
    }

    private Vector3 SetPosition()
    {
        return new Vector3(Random.Range(_leftBoundtTransform.position.x, _rightBoundtTransform.position.x),_transform.position.y, Random.Range(_frontBoundtTransform.position.z, _backBoundtTransform.position.z));
    }

    private void OnResetPosition()
    {
        foreach (GameObject bush in _bushesInGame)
        {
            bush.transform.position = SetPosition();
        }
    }
}
