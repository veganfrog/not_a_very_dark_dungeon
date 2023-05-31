using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class DamageTextController : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject[] enemyInstance;
    public string TextToDisplay;


        public void DisplayDamage(GameObject clickedObject, int damage)
        {
            GameObject DamageTextInstance = Instantiate(damageTextPrefab, clickedObject.transform);
            DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().text = damage.ToString();
        }
      
}
