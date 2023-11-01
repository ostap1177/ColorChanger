using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private Image _hearthFull;
    [SerializeField] private Image _hearthHalf;
    [SerializeField] private Image _hearthNull;
    [SerializeField] private Player _player;

    private const int _halfHeart = 2;
    private const int _nullHeart = 1;



    private void OnEnable()
    {
        _player.PlayerHealthDamaged += OnDisplayHeart;
    }

    private void OnDisable()
    {
        _player.PlayerHealthDamaged -= OnDisplayHeart;
    }

    private void OnDisplayHeart(int health)
    {
        if(health > 0 && health <= _player.Health)
        {
            switch (health)
            {
                case _halfHeart:
                    _hearthFull.gameObject.SetActive(false);
                    _hearthHalf.gameObject.SetActive(true);
                    _hearthNull.gameObject.SetActive(false);
                    break;
                case _nullHeart:
                    _hearthFull.gameObject.SetActive(false);
                    _hearthHalf.gameObject.SetActive(false);
                    _hearthNull.gameObject.SetActive(true);
                    break;
                default:
                    _hearthFull.gameObject.SetActive(true);
                    _hearthHalf.gameObject.SetActive(false);
                    _hearthNull.gameObject.SetActive(false);
                    break;
            }
        }
    }
}
