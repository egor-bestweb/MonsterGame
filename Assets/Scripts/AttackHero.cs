using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHero : MonoBehaviour
{
    private float damage = 0.15f;

    public void ApplyDamage()
    {
        hero_devicing.plManager.Health -= damage;
    }
}
