using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private int _damage = 1;

    public int Damge { get; private set;}

    private float _speed;
    private Transform _transform;

    private void Start()
    {
        Damge = _damage;
        _transform = transform;
    }

    private void Update()
    {
        _transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        gameObject.SetActive(false);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetColor(Material material)
    {
        if (_damage == 0)
        {
            _renderer.materials[0].color = material.color;
        }
    }
}
