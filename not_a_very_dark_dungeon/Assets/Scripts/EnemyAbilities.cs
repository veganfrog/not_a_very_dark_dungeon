using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAbilities : MonoBehaviour
{
    [SerializeField]
    public AudioClip RatBiteAudio;
    public AudioClip RabidBiteAudio;
    public AudioClip SlimeAudio;
    public AudioClip ShankAudio;
    public AudioClip BashAudio;
    public AudioClip SpitAudio;
    public AudioSource AudioSource;
    public List<GameObject> FriendlyPlayers ;
    public Stats stats ;
    public TurnController turnController ;
    private GameObject target;
    //TARGET SELECTION
    public void RatBite()
    {
        int randomIndex = Random.Range(0, FriendlyPlayers.Count);
        switch (randomIndex)
        {
            case 0:
                GameObject target = FriendlyPlayers[randomIndex];
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
                
                GameObject  target = FriendlyPlayers[randomIndex];
                Debug.Log("hit crusader");
                RabidBiteDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                Debug.Log("hit hwm");
                RabidBiteDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                Debug.Log("hit pd");
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
                GameObject target = FriendlyPlayers[randomIndex];
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
                GameObject target = FriendlyPlayers[randomIndex];
                SlimeBashDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                SlimeBashDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                SlimeBashDamage(target);
                break;
        }
    }
    public void Shank()
    {
        int randomIndex = Random.Range(0, FriendlyPlayers.Count);
        switch (randomIndex)
        {
            case 0:
                GameObject target = FriendlyPlayers[randomIndex];
                ShankDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                ShankDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                ShankDamage(target);
                break;
        }
    }
    public void Bash()
    {
        int randomIndex = Random.Range(0, FriendlyPlayers.Count);
        switch (randomIndex)
        {
            case 0:
                GameObject target = FriendlyPlayers[randomIndex];
                BashDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                BashDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                BashDamage(target);
                break;
        }
    }
    public void Spit()
    {
        int randomIndex = Random.Range(0, FriendlyPlayers.Count);
        switch (randomIndex)
        {
            case 0:
                GameObject target = FriendlyPlayers[randomIndex];
                SpitDamage(target);
                break;
            case 1:
                target = FriendlyPlayers[randomIndex];
                SpitDamage(target);
                break;
            case 2:
                target = FriendlyPlayers[randomIndex];
                SpitDamage(target);
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
        AudioSource.clip = RatBiteAudio;
        AudioSource.Play();
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
        AudioSource.clip = RabidBiteAudio;
        AudioSource.Play();
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
        AudioSource.clip = SpitAudio;
        AudioSource.Play();
        Debug.Log(Damage);
    }
    public void SlimeBashDamage(GameObject target)
    {
        int AbilityDamage = Random.Range(1, 3);
        int Damage = stats.BaseDamage + AbilityDamage;
        stats.Health -= Damage;
        int StunChance = 90;
        StunChance -= target.GetComponent<Stats>().StunResist;
        int StunRoll = Random.Range(1, 100);
        target.GetComponent<Stats>().Health -= Damage;
        if (target.GetComponent<Stats>().Health <= 0)
        {
            Destroy(target);
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
        turnController.ReadyUp();
        AudioSource.clip = SlimeAudio;
        AudioSource.Play();
        Debug.Log(Damage);
    }

    //HOBO ATTACKS
    public void ShankDamage(GameObject target)
    {
        Debug.Log("SHANK");
        int AbilityDamage = Random.Range(4, 12);
        int Damage = stats.BaseDamage + AbilityDamage;
        stats.Health -= Damage;
        int BleedChance = 80;
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
            stats.BleedDamage += 4;
            Debug.Log("BLED FOR 4 DAAMGE");
        }
        else
        {
            Debug.Log("COULNDT BLEED");
        }
        turnController.ReadyUp();
        AudioSource.clip = ShankAudio;
        AudioSource.Play();
        Debug.Log(Damage);
    }
    public void BashDamage(GameObject target)
    {
        int AbilityDamage = Random.Range(2, 5);
        int Damage = stats.BaseDamage + AbilityDamage;
        stats.Health -= Damage;
        int StunChance = 110;
        StunChance -= target.GetComponent<Stats>().StunResist;
        int StunRoll = Random.Range(1, 100);
        target.GetComponent<Stats>().Health -= Damage;
        if (target.GetComponent<Stats>().Health <= 0)
        {
            Destroy(target);
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
        AudioSource.clip = BashAudio;
        AudioSource.Play();
        turnController.ReadyUp();
        Debug.Log(Damage);
    }
    public void SpitDamage(GameObject target)
    {
        Debug.Log("HE SPAT");
        int AbilityDamage = Random.Range(1, 5);
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
            stats.PoisonDamage += 5;
            Debug.Log("Blighed FOR 5 DAAMGE");
        }
        else
        {
            Debug.Log("COULNDT Blight");
        }
        turnController.ReadyUp();
        AudioSource.clip = SpitAudio;
        AudioSource.Play();
        Debug.Log(Damage);
    }
}
