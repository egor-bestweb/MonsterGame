using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] targets; // Это gates

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hero_devicing.plManager.Access && other.name == "Hero")
        {
            foreach(GameObject targer in targets)
                targer.SendMessage("Activate");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (GameObject targer in targets)
            targer.SendMessage("Deactivate");
    }
}
