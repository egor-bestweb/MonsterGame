using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class UIController : MonoBehaviour
{
    private bool accsessKey;
    private float hp;
    private float _time;
    [SerializeField] private Image key;
    [SerializeField] private TextMeshProUGUI txt_hp;
    [SerializeField] private TextMeshProUGUI txt_time;

    private void Start()
    {
        _time = 30.0f; 
    }

    private void Update()
    {
        hp = hero_devicing.plManager.Health;
        accsessKey = hero_devicing.plManager.Access;
        if (accsessKey)
        {
            {
                key.color = new Color(255, 213, 0, 255);
            }
        }

        txt_hp.text = System.Convert.ToString("Health: " + (int)hp);


        //--------------TIME---------------//
        _time -= Time.deltaTime;
        txt_time.text = System.Convert.ToString("Rest of time: " + Mathf.Round(_time));

    }
}
