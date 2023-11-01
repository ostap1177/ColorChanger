using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBarrier : SpawnPool
{
    [SerializeField] private Barrier _barrier;
    [SerializeField] private Barrier _barrierDamage;
    [SerializeField] private List<Material> _colorsBarrier;
    [SerializeField] private int _capacityBarriers;
    [SerializeField] private int _capacityBarriersDamage;
    [SerializeField] private Transform _boundSpawnLeft;
    [SerializeField] private Transform _boundSpawnRight;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _secondBetweenSpawn;
    [SerializeField] private float _speedBarrier;

    private int _numberColor = 0;
    private int _temporaryNumberColor = 0;
    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_barrier.gameObject, _capacityBarriers);
        Initialize(_barrierDamage.gameObject, _capacityBarriersDamage);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondBetweenSpawn)
        { 
            if (TryGetObject(out GameObject gameObject) == true)
            {
                if (gameObject.TryGetComponent<Barrier>(out Barrier barrier) == true)
                {
                    _elapsedTime = 0;
                    if (barrier.Damge == 0)
                    {
                        SetBarrier(barrier, GetSpawnPoint(), GetMaterial());
                    }
                    else
                    {
                        SetBarrier(barrier, GetSpawnPoint());
                    }
                }
            }
        }
    }

    private Vector3 GetSpawnPoint()
    {
        float spawnPointX = UnityEngine.Random.Range(_boundSpawnLeft.position.x, _boundSpawnRight.position.x);
     
        return new Vector3(spawnPointX, _spawnPoint.position.y, _spawnPoint.position.z);
    }

    private void SetBarrier(Barrier barrier, Vector3 spawnPoint, Material material = null)
    {
        barrier.gameObject.SetActive(true);
        barrier.SetSpeed(_speedBarrier);
        barrier.SetColor(material);

        barrier.transform.position = spawnPoint;
    }

    private Material GetMaterial()
    {
        _numberColor = UnityEngine.Random.Range(0, _colorsBarrier.Count);

        while (_numberColor == _temporaryNumberColor)
        {
            _numberColor = UnityEngine.Random.Range(0, _colorsBarrier.Count);
        }

        _temporaryNumberColor = _numberColor;

        return _colorsBarrier[_numberColor];
    }
}
