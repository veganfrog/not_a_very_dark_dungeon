using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAbilities : MonoBehaviour
{
   public List<GameObject> FriendlyPlayers ;
    public Stats stats ;
    public TurnController turnController ;
    GameObject target;
    //TARGET SELECTION
    public void RatBite()
    {
        int randomIndex = Random.Range(0, FriendlyPlayers.Count);
        switch (randomIndex)
        {
            case 0:
                target = FriendlyPlayers[randomIndex];
                RatBiteDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                RatBiteDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                RatBiteDamage(target);
                break;
        }

    }
    public void RabidBite()
    {
        int randomIndex = Random.Range(0, FriendlyPlayers.Count);
        switch (randomIndex)
        {
            case 0:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
        }
    }
    public void DiseasedSpit()
    {
        int randomIndex = Random.Range(0, FriendlyPlayers.Count);
        switch (randomIndex)
        {
            case 0:
                target = FriendlyPlayers[randomIndex];
                DiseasedSpitDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                DiseasedSpitDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                DiseasedSpitDamage(target);
                break;
        }
    }
    public void SlimeBash()
    {
        int randomIndex = Random.Range(0, FriendlyPlayers.Count);
        switch (randomIndex)
        {
            case 0:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
        }
    }
    public void Shank()
    {
        int randomIndex = Random.Range(0, FriendlyPlayers.Count);
        switch (randomIndex)
        {
            case 0:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
        }
    }
    public void Bash()
    {
        int randomIndex = Random.Range(0, FriendlyPlayers.Count);
        switch (randomIndex)
        {
            case 0:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
        }
    }
    public void Spit()
    {
        int randomIndex = Random.Range(0, FriendlyPlayers.Count);
        switch (randomIndex)
        {
            case 0:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                RabidBiteDamage(target);
                break;
        }
    }


    //ACTUAL DAMAGE
    public void RatBiteDamage(GameObject target)
    {
        Debug.Log("RAT BITE");
        int AbilityDamage = Random.Range(2, 4);
        int Damage = stats.BaseDamage + AbilityDamage;
        stats.Health -= Damage;
        target.GetComponent<Stats>().Health -= Damage;
        if (target.GetComponent<Stats>().Health <= 0)
        {
            Destroy(target);
        }
        turnController.ReadyUp();
        Debug.Log(Damage);
    }
    public void RabidBiteDamage(GameObject target)
    {
        Debug.Log("DOG BITE");
        int AbilityDamage = Random.Range(2, 8);
        int Damage = stats.BaseDamage + AbilityDamage;
        stats.Health -= Damage;
        int BleedChance = 60;
        BleedChance -= target.GetComponent<Stats>().BleedResist;
        int BleedRoll = Random.Range(1, 100);
        target.GetComponent<Stats>().Health -= Damage;
        if (target.GetComponent<Stats>().Health <= 0)
        {
            Destroy(target);
        }
        else if (BleedRoll <= BleedChance)
        {
            //Bleed enemy
            stats.BleedDamage += 2;
            Debug.Log("BLED FOR 2 DAAMGE");
        }
        else
        {
            Debug.Log("COULNDT BLEED");
        }
        turnController.ReadyUp();
        Debug.Log(Damage);
    }
    public void DiseasedSpitDamage(GameObject target)
    {
        Debug.Log("RAT SPIT");
        int AbilityDamage = Random.Range(2, 8);
        int Damage = stats.BaseDamage + AbilityDamage;
        stats.Health -= Damage;
        int PoisonChance = 40;
        PoisonChance -= target.GetComponent<Stats>().PoisonResist;
        int PoisonRoll = Random.Range(1, 100);
        target.GetComponent<Stats>().Health -= Damage;
        if (target.GetComponent<Stats>().Health <= 0)
        {
            Destroy(target);
        }
        else if (PoisonRoll <= PoisonChance)
        {
            //Poison enemy
            stats.BleedDamage += 3;
            Debug.Log("Blighed FOR 3 DAAMGE");
        }
        else
        {
            Debug.Log("COULNDT Blight");
        }
        turnController.ReadyUp();
        Debug.Log(Damage);
    }

}
