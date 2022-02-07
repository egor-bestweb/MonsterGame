using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSound : MonoBehaviour
{
    [SerializeField] private AudioSource clip;

    private void Update()
    {
        if (hero_devicing.plManager.Noticed)
        {
            clip.pitch = 1.2f;
            clip.volume = 0.7f;
        }
    }
}
