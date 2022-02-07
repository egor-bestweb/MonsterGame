using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_light : MonoBehaviour
{
    [SerializeField] private Transform hero;

    private void Update()
    {
        transform.position = new Vector3(hero.position.x, hero.position.y, transform.position.z);
        transform.rotation = hero.rotation;
    }
}
