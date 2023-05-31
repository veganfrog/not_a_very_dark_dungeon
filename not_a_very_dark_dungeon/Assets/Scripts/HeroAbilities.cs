using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Random;

public class HeroAbilities : MonoBehaviour
{
    public TurnController TurnController;
    // stat blocks
    public Stats stats;
    public UIController UIcontroller;
    public DamageTextController DamageTextController;



    public bool IsTurn;
    //Selected attacker status
    public bool CrusaderReady = false;
    public bool HWMReady = false;
    public bool PlagueReady = false;

    //Crusader attack status
    public bool ReadyingSmite = false;
    public bool ReadyingAccusativeScroll = false;
    public bool ReadyingStunningStrike = false;
    //HWM attack status
    public bool ReadyingPistolShot = false;
    public bool ReadyingGrapeshotBlast = false;
    public bool ReadyingSlash = false;
    //Plague doctor attack status
    public bool ReadyingStunningBomb = false;
    public bool ReadyingPlagueBomb = false;
    public bool ReadyingBattleMedicine = false;



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
        //HWM attacks
        if (HWMReady && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E)))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                int i = 1;
                SelectingHWMAttack(i);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                int i = 2;
                SelectingHWMAttack(i);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                int i = 3;
                SelectingHWMAttack(i);
            }

        }
        //Plague doctors attacks
        if (PlagueReady && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E)))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                int i = 1;
                SelectingPlagueAttack(i);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                int i = 2;
                SelectingPlagueAttack(i);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                int i = 3;
                SelectingPlagueAttack(i);
            }

        }




    }

    // HERO ABILITIES

    // Crusader abilities
    public void Smite(GameObject clickedObject)
    {
<<<<<<< Updated upstream
        int y = 1;
=======
        int y =1;
>>>>>>> Stashed changes
        int AbilityDamage = Range(4, 10);
        int Damage = stats.BaseDamage + AbilityDamage;
        stats.Health -= Damage;
        clickedObject.GetComponent<Stats>().Health -= Damage;
        if (clickedObject.GetComponent<Stats>().Health <= 0)
        {
            GameObject character = clickedObject;
            TurnController.IsAlive(character);
            
            Destroy(clickedObject);
        }
        DamageTextController.DisplayDamage(clickedObject,Damage);
        UIcontroller.ReadyUI(y);
        TurnController.ReadyUp();
<<<<<<< Updated upstream
        UIcontroller.ReadyUI(y);
=======
     
>>>>>>> Stashed changes
        Debug.Log(Damage);
    }
    public void AccusativeScroll(GameObject clickedObject1, GameObject clickedObject2)
    {
        // damages  first two enemies
        int y = 1;
        int AbilityDamage = Range(2, 6);
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
<<<<<<< Updated upstream
        UIcontroller.ReadyUI(y);
=======
        GameObject clickedObject = clickedObject1;
        DamageTextController.DisplayDamage(clickedObject, Damage);
        clickedObject = clickedObject2;
        DamageTextController.DisplayDamage(clickedObject, Damage);
>>>>>>> Stashed changes
        TurnController.ReadyUp();


    }
    public void StunningStrike(GameObject clickedObject)
    {
        // attemps to stun one enemy
        int y = 1;
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
        else
        {
            Debug.Log("COULNDT STUN");
        }

        DamageTextController.DisplayDamage(clickedObject, Damage);
       
        Debug.Log(Damage);
        UIcontroller.ReadyUI(y);
        TurnController.ReadyUp();

    }
    //HWM ABILITIES
    public void PistolShot(GameObject clickedObject)
    {
        int y = 2;
        int AbilityDamage = Range(3, 6);
        int Damage = stats.BaseDamage + AbilityDamage;
        stats.Health -= Damage;
        clickedObject.GetComponent<Stats>().Health -= Damage;
        if (clickedObject.GetComponent<Stats>().Health <= 0)
        {
            Destroy(clickedObject);
        }
<<<<<<< Updated upstream
        UIcontroller.ReadyUI(y);
=======
        DamageTextController.DisplayDamage(clickedObject, Damage);
>>>>>>> Stashed changes
        TurnController.ReadyUp();
        Debug.Log(Damage);
    }
    public void GrapeshotBlast(GameObject clickedObject1, GameObject clickedObject2, GameObject clickedObject3)
    {
        // damages  first three enemies
        int y = 2;
        int AbilityDamage = Range(2, 6);
        int Damage = stats.BaseDamage + AbilityDamage;
        if (clickedObject1 != null && clickedObject2 != null && clickedObject3 != null)
        {
            Debug.Log("HIT All ENEMIES");

            clickedObject1.GetComponent<Stats>().Health -= Damage;
            clickedObject2.GetComponent<Stats>().Health -= Damage;
            clickedObject3.GetComponent<Stats>().Health -= Damage;
            if (clickedObject1.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject1);
            }

            if (clickedObject2.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject2);
            }
            if (clickedObject3.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject3);
            }

            Debug.Log(Damage);
        }
        else if (clickedObject1 != null && clickedObject2 == null && clickedObject3 != null)
        {
            clickedObject1.GetComponent<Stats>().Health -= Damage;
            clickedObject3.GetComponent<Stats>().Health -= Damage;
            if (clickedObject1.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject1);
            }
            if (clickedObject3.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject3);
            }
        }
        else if (clickedObject1 != null && clickedObject2 != null && clickedObject3 == null)
        {
            clickedObject1.GetComponent<Stats>().Health -= Damage;
            clickedObject2.GetComponent<Stats>().Health -= Damage;

            if (clickedObject1.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject2);

            }
            if (clickedObject2.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject2);

            }
        }


        else if (clickedObject1 == null && clickedObject2 != null && clickedObject3 != null)
        {
            clickedObject2.GetComponent<Stats>().Health -= Damage;
            clickedObject3.GetComponent<Stats>().Health -= Damage;

            if (clickedObject2.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject2);
            }
            if (clickedObject3.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject3);
            }
        }
        else if (clickedObject1 != null && clickedObject2 == null && clickedObject3 == null)
        {
            clickedObject1.GetComponent<Stats>().Health -= Damage;

            if (clickedObject1.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject1);
            }

        }
        else if (clickedObject1 == null && clickedObject2 != null && clickedObject3 == null)
        {
            clickedObject2.GetComponent<Stats>().Health -= Damage;


            if (clickedObject2.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject2);
            }

        }
        else if (clickedObject1 == null && clickedObject2 == null && clickedObject3 != null)
        {

            clickedObject3.GetComponent<Stats>().Health -= Damage;

            if (clickedObject3.GetComponent<Stats>().Health <= 0)
            {
                Destroy(clickedObject3);
            }

        }
<<<<<<< Updated upstream
        UIcontroller.ReadyUI(y);
        TurnController.ReadyUp();
=======
        GameObject clickedObject = clickedObject1;
        DamageTextController.DisplayDamage(clickedObject, Damage);
        clickedObject = clickedObject2;
        DamageTextController.DisplayDamage(clickedObject, Damage);
        clickedObject = clickedObject3;
        DamageTextController.DisplayDamage(clickedObject, Damage);

        TurnController.ReadyUp();

>>>>>>> Stashed changes


    }
    public void Slash(GameObject clickedObject)
    {
        // attemps to stun one enemy
        int y = 2;
        int AbilityDamage = Range(2, 4);
        int Damage = stats.BaseDamage + AbilityDamage;
        stats.Health -= Damage;
        int BleedChance = 90;
        BleedChance -= clickedObject.GetComponent<Stats>().BleedResist;
        int BleedRoll = Range(1, 100);
        clickedObject.GetComponent<Stats>().Health -= Damage;
        if (clickedObject.GetComponent<Stats>().Health <= 0)
        {
            Destroy(clickedObject);
        }
        else if (BleedRoll <= BleedChance)
        {
            //Bleed enemy
            stats.BleedDamage += 4;
            Debug.Log("BLED FOR 2 DAAMGE");
        }
        else
        {
            Debug.Log("COULNDT BLEED");
        }
        DamageTextController.DisplayDamage(clickedObject, Damage);
        Debug.Log(Damage);
        UIcontroller.ReadyUI(y);
        TurnController.ReadyUp();

    }
    // Plague Doctor Abilities
    public void StunningBomb(GameObject clickedObject)
    {
        int y = 3;
        Debug.Log("activated");
        int AbilityDamage = Range(1, 3);
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
        else
        {
            Debug.Log("COULNDT STUN");
        }
<<<<<<< Updated upstream
        UIcontroller.ReadyUI(y);
=======
        DamageTextController.DisplayDamage(clickedObject, Damage);
>>>>>>> Stashed changes
        TurnController.ReadyUp();
        Debug.Log(Damage);
    }
    public void PlagueBomb(GameObject clickedObject)
    {
        int y = 3;
        int AbilityDamage = Range(1, 5);
        int Damage = stats.BaseDamage + AbilityDamage;
        stats.Health -= Damage;
        int PoisonChance = 90;
        PoisonChance -= clickedObject.GetComponent<Stats>().PoisonResist;
        int PoisonRoll = Range(1, 100);
        clickedObject.GetComponent<Stats>().Health -= Damage;
        if (clickedObject.GetComponent<Stats>().Health <= 0)
        {
            Destroy(clickedObject);
        }
        else if (PoisonRoll <= PoisonChance)
        {
            //Poison enemy
            stats.PoisonDamage += 5;
            Debug.Log("Blighed FOR 5 DAAMGE");
        }
        else
        {
            Debug.Log("COULNDT Blight");
        }
<<<<<<< Updated upstream
        UIcontroller.ReadyUI(y);
=======
        DamageTextController.DisplayDamage(clickedObject, Damage);
>>>>>>> Stashed changes
        TurnController.ReadyUp();
        Debug.Log(Damage);
    }
    public void BattleMedicine(GameObject clickedObject)
    {
        int y = 3;
        int AbilityDamage = Range(1, 5);
        int Damage = stats.BaseDamage + AbilityDamage;
        clickedObject.GetComponent<Stats>().Health += Damage;
        clickedObject.GetComponent<Stats>().BleedDamage = 0;
        clickedObject.GetComponent<Stats>().PoisonDamage = 0;
<<<<<<< Updated upstream
        UIcontroller.ReadyUI(y);
=======
        DamageTextController.DisplayDamage(clickedObject, Damage);
>>>>>>> Stashed changes
        TurnController.ReadyUp();
        Debug.Log(Damage);
    }


    //CHARACTER SELECTION
    public void SelectingAttacker(int i)
    {
        int y;
        switch (i)
        {
            case 1:
                if (!CrusaderReady)
                {
                    y = 1;

                    UIcontroller.ReadyUI(y);


                    CrusaderReady = true;
                    Debug.Log("READYING CRUSADER FOR ATTACK");
                }
                else if (CrusaderReady)
                {
                    CrusaderReady = false;
                    Debug.Log("NOT READYING CRUSADER FOR ATTACK AND UNSELECTING ATTACKS");
                    ReadyingSmite = false;
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
                    ReadyingPistolShot = false;
                    ReadyingGrapeshotBlast = false;
                    ReadyingSlash = false;
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
                    ReadyingStunningBomb = false;
                    ReadyingPlagueBomb = false;
                    ReadyingBattleMedicine = false;
                }
                break;

        }
    }

    //SELECTING CRUSADERS ATTACK
    public void SelectingCrusadersAttack(int i)
    {
        switch (i)
        {
            //SMITE
            case 1:

                if (CrusaderReady && !ReadyingSmite && !ReadyingAccusativeScroll && !ReadyingStunningStrike)
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

                if (CrusaderReady && !ReadyingSmite && !ReadyingAccusativeScroll && !ReadyingStunningStrike)
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
                if (CrusaderReady && !ReadyingSmite && !ReadyingAccusativeScroll && !ReadyingStunningStrike)
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
    public void SelectingHWMAttack(int i)
    {
        switch (i)
        {
            //SMITE
            case 1:

                if (HWMReady && !ReadyingPistolShot && !ReadyingGrapeshotBlast && !ReadyingSlash)
                {
                    ReadyingPistolShot = true;

                }
                else if (HWMReady && ReadyingPistolShot)
                {
                    ReadyingPistolShot = false;
                }
                break;

            //ACCUSATIVE SCROLL
            case 2:

                if (HWMReady && !ReadyingPistolShot && !ReadyingGrapeshotBlast && !ReadyingSlash)
                {
                    ReadyingGrapeshotBlast = true;
                }
                else if (HWMReady && ReadyingGrapeshotBlast)
                {
                    ReadyingGrapeshotBlast = false;

                }
                break;
            //STUNNING STRIKE
            case 3:
                if (HWMReady && !ReadyingPistolShot && !ReadyingGrapeshotBlast && !ReadyingSlash)
                {
                    ReadyingSlash = true;


                }
                else if (HWMReady && ReadyingSlash)
                {
                    ReadyingSlash = false;
                }

                break;


        }
    }
    public void SelectingPlagueAttack(int i)
    {
        switch (i)
        {
            case 1:

                if (PlagueReady && !ReadyingStunningBomb && !ReadyingPlagueBomb && !ReadyingBattleMedicine)
                {
                    ReadyingStunningBomb = true;

                }
                else if (PlagueReady && ReadyingStunningBomb)
                {
                    ReadyingStunningBomb = false;
                }
                break;

            case 2:

                if (PlagueReady && !ReadyingStunningBomb && !ReadyingPlagueBomb && !ReadyingBattleMedicine)
                {
                    ReadyingPlagueBomb = true;
                }
                else if (PlagueReady && ReadyingPlagueBomb)
                {
                    ReadyingPlagueBomb = false;

                }
                break;
            case 3:
                if (PlagueReady && !ReadyingStunningBomb && !ReadyingPlagueBomb && !ReadyingBattleMedicine)
                {
                    ReadyingBattleMedicine = true;


                }
                else if (PlagueReady && ReadyingBattleMedicine)
                {
                    ReadyingBattleMedicine = false;
                }

                break;


        }
    }
}
