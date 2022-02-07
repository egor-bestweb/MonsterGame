using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicUI : MonoBehaviour
{
    private bool _active = false;
    [SerializeField] private GameObject _canvas;

    private void Start()
    {
        Debug.Log("Pressed");
        _canvas.SetActive(_active);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _active = !_active;
            Debug.Log("Updated");
        }


        _canvas.SetActive(_active);
    }
}
