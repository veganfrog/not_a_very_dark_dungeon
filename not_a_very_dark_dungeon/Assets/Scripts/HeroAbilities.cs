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

    public TurnController TurnController;
    // stat blocks
    public Stats stats;




    public bool IsTurn;
    //Selected attacker status
    public bool CrusaderReady = false;
    public bool HWMReady = false;
    public bool PlagueReady = false;
    
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
    {
        //Selecting an attacker



        //ATTACKS

            //CRUSADERS ATTACKS
            if (CrusaderReady && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E)))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                int i = 1;
                SelectingCrusadersAttack(i);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                int i = 2;
                SelectingCrusadersAttack(i);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                int i = 3;
                SelectingCrusadersAttack(i);
            }

        }


        

    }   

    // HERO ABILITIES
       
        // Crusader abilities
        public void Smite(GameObject clickedObject)
        {
            int AbilityDamage = Range(4, 10);
            int Damage = stats.BaseDamage + AbilityDamage ;
            stats.Health -= Damage ;
            clickedObject.GetComponent<Stats>().Health -= Damage;
            if (clickedObject.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject);
            }
        TurnController.ReadyUp();
            Debug.Log(Damage);
        }
        public  void AccusativeScroll(GameObject clickedObject1, GameObject clickedObject2)
        {
        // damages  first two enemies

        int AbilityDamage = Range(2, 6  );
        int Damage = stats.BaseDamage + AbilityDamage;
        if (clickedObject1 != null && clickedObject2 != null)
        {
            Debug.Log("HIT BOTH ENEMIES");

            clickedObject1.GetComponent<Stats>().Health -= Damage;
            clickedObject2.GetComponent<Stats>().Health -= Damage;
            if (clickedObject1.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject1);
            }

            if (clickedObject2.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject2);
            }

            Debug.Log(Damage);
        }
        else if (clickedObject1 != null && clickedObject2 == null)
        {
            clickedObject1.GetComponent<Stats>().Health -= Damage;
            if (clickedObject1.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject1);
            }
        }
        else
        {

            Debug.Log("HIT SECOND ENEMY");
            if (clickedObject2.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject2);
            }
        }
        TurnController.ReadyUp();


    }
        public void StunningStrike(GameObject clickedObject)
        {
        // attemps to stun one enemy
        int AbilityDamage = Range(2, 4);
        int Damage = stats.BaseDamage + AbilityDamage;
        stats.Health -= Damage;
        int StunChance = 90;
        StunChance -= clickedObject.GetComponent<Stats>().StunResist;
        int StunRoll = Range(1, 100);
        clickedObject.GetComponent<Stats>().Health -= Damage;
        if (clickedObject.GetComponent<Stats>().Health <= 0)
        {
            Destroy(clickedObject);
        }
        else if (StunRoll <= StunChance)
        {
            //STUN ENEMY
            stats.IsStunned = true;
            Debug.Log("STUNNED");
        }
        else {
            Debug.Log("COULNDT STUN");
                }
        

        Debug.Log(Damage);
        TurnController.ReadyUp();

    }

    //CHARACTER SELECTION
    public void SelectingAttacker(int i)
    {
        switch(i)
        {
            case 1:
                if (!CrusaderReady)
                {
                    CrusaderReady = true;
                    Debug.Log("READYING CRUSADER FOR ATTACK");
                }
                else if (CrusaderReady)
                {
                    CrusaderReady = false;
                    Debug.Log("NOT READYING CRUSADER FOR ATTACK AND UNSELECTING ATTACKS");
                    ReadyingSmite = false;
                    ReadyingProtectiveLight = false;
                    ReadyingAccusativeScroll = false;
                    ReadyingStunningStrike = false;
                }
                break;
            case 2:
                if (!HWMReady)
                {
                    HWMReady = true;
                    Debug.Log("READYING HIGHWAYMAN FOR ATTACK");
                }
                else if (HWMReady)
                {
                    HWMReady = false;
                    Debug.Log("NOT READYING HIGHWAYMAN FOR ATTACK");
                }
                break;
            case 3:
                if (!PlagueReady)
                {
                    PlagueReady = true;
                    Debug.Log("READYING PLAGUE DOCTOR FOR ATTACK");
                }
                else if (PlagueReady)
                {
                    PlagueReady = false;
                    Debug.Log("NOT READYING PLAGUE DOCTOR FOR ATTACK");
                }
                break;
   
        }
    }
    //SELECTING CRUSADERS ATTACK
    public void SelectingCrusadersAttack(int i )
    {
        switch (i) {
            //SMITE
            case 1:
                
                    if (CrusaderReady && !ReadyingSmite)
                    {
                        ReadyingSmite = true;
                        Debug.Log("READYING SMITE");
                    }
                    else if (CrusaderReady && ReadyingSmite)
                    {
                        ReadyingSmite = false;
                        Debug.Log("NOT READYING SMITE");
                    }
                break;

            //ACCUSATIVE SCROLL
            case 2:

                if (CrusaderReady && !ReadyingAccusativeScroll)
                {
                    ReadyingAccusativeScroll = true;
                    Debug.Log("READYING ACCUSATIVE SCROLL");
                }
                else if (CrusaderReady && ReadyingAccusativeScroll)
                {
                    ReadyingAccusativeScroll = false;
                    Debug.Log("NOT READYING ACCUSATIVE SCROLL");
                }
                break;
            //STUNNING STRIKE
            case 3:
                if (CrusaderReady && !ReadyingStunningStrike)
                {
                    ReadyingStunningStrike = true;
                    Debug.Log("READYING STUNNING STRIKE");


                }
                else if (CrusaderReady && ReadyingStunningStrike)
                {
                    ReadyingStunningStrike = false;

                    Debug.Log("NOT READYING STUNNING STRIKE");
           }

                break;


        }



        

        
        
        
        
       
       
    }
}
