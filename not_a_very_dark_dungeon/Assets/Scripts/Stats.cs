using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public string Name;
    public int Health;
    public int MaxHealth;
    public int BaseDamage;
    public int Speed;
    public int BleedResist;
    public int PoisonResist;
    public int StunResist;
    public int BleedDamage;
    public int PoisonDamage;
    public bool IsStunned;

    public TMP_Text healthText;
    public void DOTDamage(GameObject currentCharacter)
    {
        if (BleedDamage != 0)
        {
            currentCharacter.GetComponent<Stats>().Health -= BleedDamage;
            BleedDamage--;
        }
        if(PoisonDamage!= 0) {

            currentCharacter.GetComponent<Stats>().Health -= PoisonDamage;
            PoisonDamage--;
        }
    }
    public void UpdateTextBoxes()
    {
        healthText.text = Health.ToString();
    }
    private void Update()
    {
        UpdateTextBoxes();
    }
}


