using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Random;

public class HeroAbilities : MonoBehaviour
{
  //TODO : MAKE IT SO THAT YOU CANT EXIT OUT OF A CHARACTER WHILE DOING AN ATTACK

    //Enemy stat blocks
    public Stats stats;

    //Friendly stat blocks 
    public CrusaderScript crusaderscript;
    //in game enemy and friendly objects
    public GameObject Crusader;
    public GameObject Enemy1;


    //Attack status
    public bool CrusaderReady = false;
    public bool HWMReady = false;
    public bool PlagueReady = false;
    public bool OccultistReady = false;
    
    //Crusader attack status
    public bool ReadyingSmite = false;
    public bool ReadyingProtectiveLight = false;
    public bool ReadyingAccusativeScroll = false;
    public bool ReadyingStunningStrike = false;
    //HWM attack status

    //Plague doctor attack status

    // Occultist attack status


    private void Start()
    {
        Debug.Log("started");
    }
    private void Update()
    {   //Selecting an attacker


            // SELECTING CRUSADER
            if (!CrusaderReady && Input.GetKeyDown(KeyCode.Alpha1))
            {
                CrusaderReady = true;
                Debug.Log("READYING CRUSADER FOR ATTACK");
            }
            else if (CrusaderReady && Input.GetKeyDown(KeyCode.Alpha1))
            {
                CrusaderReady = false;
                Debug.Log("NOT READYING CRUSADER FOR ATTACK");
            }
            //SELECTING HWM
            if (!HWMReady && Input.GetKeyDown(KeyCode.Alpha2))
            {
                HWMReady = true;
                Debug.Log("READYING HIGHWAYMAN FOR ATTACK");
            }
            else if (HWMReady && Input.GetKeyDown(KeyCode.Alpha2))
            {
                HWMReady = false;
                Debug.Log("NOT READYING HIGHWAYMAN FOR ATTACK");
            }

            //SELECTING PLAGUE DOCTOR
            if (!PlagueReady && Input.GetKeyDown(KeyCode.Alpha3))
            {
                PlagueReady = true;
                Debug.Log("READYING PLAGUE DOCTOR FOR ATTACK");
            }
            else if (PlagueReady && Input.GetKeyDown(KeyCode.Alpha3))
            {
                PlagueReady = false;
                Debug.Log("NOT READYING PLAGUE DOCTOR FOR ATTACK");
            }

            //SELECTING OCCULTIST

            if (!OccultistReady && Input.GetKeyDown(KeyCode.Alpha4))
            {
                OccultistReady = true;
                Debug.Log("READYING OCCULTIST FOR ATTACK");
            }
            else if (OccultistReady && Input.GetKeyDown(KeyCode.Alpha4))
            {
                OccultistReady = false;
                Debug.Log("NOT READYING OCCULTIST FOR ATTACK");
            }

        //ATTACKS

            //CRUSADERS ATTACKS
                //SMITE
                if (CrusaderReady && !ReadyingSmite && Input.GetKeyDown(KeyCode.Q)  ){
                    ReadyingSmite = true;
                    Debug.Log("READYING SMITE");
                }
                else if(CrusaderReady && ReadyingSmite && Input.GetKeyDown(KeyCode.Q))
                {
                    ReadyingSmite = false;
                    Debug.Log("NOT READYING SMITE");
                }
               
                //PROTECTIVE LIGHT
                if (CrusaderReady && !ReadyingProtectiveLight && Input.GetKeyDown(KeyCode.W))
                {
                     ReadyingProtectiveLight = true;
                    Debug.Log("READYING PROTECTIVE LIGHT");
                }
                else if (CrusaderReady && ReadyingProtectiveLight && Input.GetKeyDown(KeyCode.W))
                {
                     ReadyingProtectiveLight = false;
                    Debug.Log("NOT READYING PROTECTIVE LIGHT");
                }
                //ACCUSATIVE SCROLL
                if (CrusaderReady && !ReadyingAccusativeScroll && Input.GetKeyDown(KeyCode.E))
                {
                   ReadyingAccusativeScroll = true;
                    Debug.Log("READYING ACCUSATIVE SCROLL");
                }
                else if (CrusaderReady && ReadyingAccusativeScroll && Input.GetKeyDown(KeyCode.E))
                {
                    ReadyingAccusativeScroll = false;
                    Debug.Log("NOT READYING ACCUSATIVE SCROLL");
                }

    }

    // HERO ABILITIES
       
        // Crusader abilities
        public void Smite(GameObject clickedObject)
        {
            int AbilityDamage = Range(4, 10);
            int Damage = crusaderscript.BaseDamage + AbilityDamage ;
            stats.Health -= Damage ;
            clickedObject.GetComponent<Stats>().Health -= Damage;
            if (clickedObject.GetComponent<Stats>().Health <= 0)
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