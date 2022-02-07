using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : MonoBehaviour
{
    private UnityEngine.Experimental.Rendering.Universal.Light2D _light;
    
    private void Start()
    {
        _light = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
    }

    private void Update()
    {
        if (hero_devicing.plManager.Noticed)
        {
            _light.intensity = 1f;
        }
    }
}
