using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Random;

public class HeroAbilities : MonoBehaviour
{
  

    //Enemy stat blocks
    public BasicRat basicRat;

    //Friendly stat blocks 
    public CrusaderScript crusaderscript;
    //in game enemy and friendly objects
    public GameObject Crusader;
    public GameObject Enemy1;


    //Attack status
   
    //Crusader attack status
    public bool ReadyingSmite = false;
    public bool ReadyingProtectiveLight = false;
    public bool ReadyingAccusativeScroll = false;
    public bool ReadyingStunningStrike = false;


    private void Start()
    {
        Debug.Log("started");
    }
    private void Update()
    {
        if (!ReadyingSmite && Input.GetKeyDown(KeyCode.Q)  ){
            ReadyingSmite = true;
            Debug.Log("READYING");
        }
        else if(ReadyingSmite && Input.GetKeyDown(KeyCode.Q))
        {
            ReadyingSmite = false;
            Debug.Log("NOT READYING");
        }
        
    }

    // Crusader abilities
    public void Smite(GameObject clickedObject)
    {
        int AbilityDamage = Range(7, 10);
        int Damage = crusaderscript.BaseDamage + AbilityDamage ;
        basicRat.Health -= Damage ;
        clickedObject.GetComponent<BasicRat>().Health -= Damage;
        if (clickedObject.GetComponent<BasicRat>().Health <= 0)
        {
            Destroy(clickedObject);
        }
        
        Debug.Log(Damage);
    }
    private void ProtectiveLight()
    {
        // gives 50% defense bonus for one attack
    }
    private void AccusativeScroll()
    {
        // damages  first two enemies
    }
    private void StunningStrike()
    {
        // attemps to stun one enemy
    }
    
}
//smite and other damage abilities make the enemiems take damage in their own scripts
// Affter clicking q 