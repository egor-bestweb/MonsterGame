using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecting : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == _enemy.name)
        {
            hero_devicing.plManager.Noticed = true;
        }
    }
}
