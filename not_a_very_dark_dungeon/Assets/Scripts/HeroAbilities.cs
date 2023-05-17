using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroAbilities : MonoBehaviour
{
   public GameObject Crusader;
    public GameObject Enemy1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            Smite();
        }
    }

    private void Smite()
    {
        Destroy(Enemy1);
    }
}
