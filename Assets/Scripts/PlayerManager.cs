using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// It contains health, info about key, weapon and maybe mental health

// Attach to hero

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform key; // drag key's module

    private bool access; // If hero get key, then it's variable switch on true, else - false
    private bool noticed; // If enemy will see own hero, it's variable switch on true, else - false
    private float health;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public bool Access
    {
        get { return access; }
        set { access = value; }
    }


    public bool Noticed
    {
        get { return noticed; }
        set { noticed = value; }
    }

    public PlayerManager()
    {
        access = false;
        noticed = false;
        health = 100;
    }




}
