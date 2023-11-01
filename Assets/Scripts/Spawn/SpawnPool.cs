using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = System.Random;

public class SpawnPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<GameObject> _poolGameObject = new List<GameObject>();

    protected void Initialize(GameObject prefab, int capacity) //GameObject container)
    {
        for (int i=0; i < capacity; i++)
        {
            GameObject gameObject = Instantiate(prefab, _container.transform.position, Quaternion.identity);
            gameObject.gameObject.SetActive(false);

            _poolGameObject.Add(gameObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _poolGameObject.FirstOrDefault(p => p.gameObject.activeSelf == false);
        _poolGameObject.Remove(result);
        _poolGameObject.Add(result);

        return result != null;
    }
}
