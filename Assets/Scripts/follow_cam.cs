﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_cam : MonoBehaviour
{
    [SerializeField] private Transform target;


    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); 
    }
}
