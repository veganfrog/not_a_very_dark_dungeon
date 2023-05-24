using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Random;

public class HeroAbilities : MonoBehaviour
{
    public Stats stats;
    public BasicRat basicRat;
    public GameObject Crusader;
    public GameObject Enemy1;
    //private ReadyingAttack = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            //ReadyingAttack = true;
        }
        
    }

    private void Smite()
    {
        int AbilityDamage = Range(7, 10);
        //int Damage = BaseDamage + AbilityDamage ;
        //stats.Health -= Damage ;
        //if(stats.Health <= 0)
        //{
        //    Destroy(Enemy1);
        //}
        //Debug.Log(Damage);
    }
    
}
//smite and other damage abilities make the enemiems take damage in their own scripts
// Affter clicking q 