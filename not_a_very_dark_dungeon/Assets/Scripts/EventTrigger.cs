using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.transform.CompareTag("Player"))
        {
            Debug.Log("ayo");
        }
    }
}
