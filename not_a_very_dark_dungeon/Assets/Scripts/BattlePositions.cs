using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattlePositions : MonoBehaviour
{
    public HeroAbilities HeroAbilities;
    public GameObject[] friendlyCubePrefabs; // Array to store the friendly cube prefabs
    public Transform[] friendlyPositions; // Array to store the friendly positions
    private GameObject[] friendlyCubes; // Array to store the friendly cubes

    public GameObject[] enemyCubePrefabs; // Array to store the enemy cube prefabs
    public Transform[] enemyPositions; // Array to store the enemy positions
    private GameObject[] enemyCubes; // Array to store the enemy cubes
    public GameObject cube;

    private void Start()
    {
        friendlyCubes = new GameObject[friendlyPositions.Length];
        enemyCubes = new GameObject[enemyPositions.Length];

        for (int i = 0; i < friendlyPositions.Length; i++)
        {
            GameObject cube = Instantiate(friendlyCubePrefabs[i]);
            cube.transform.position = friendlyPositions[i].position;
            friendlyCubes[i] = cube;
        }

        for (int i = 0; i < enemyPositions.Length; i++)
        {
            GameObject cube = Instantiate(enemyCubePrefabs[i]);
            cube.transform.position = enemyPositions[i].position;
            enemyCubes[i] = cube;
        }
    }
    private void Update()
    {
        //CRUSADER ATTACKS
        if (HeroAbilities.ReadyingSmite && Input.GetMouseButtonDown(0) && enemyCubePrefabs.Contains(cube))
        {
            int i = 1;
            SmiteEnemy();
            HeroAbilities.SelectingAttacker(i);
        }
        if (HeroAbilities.ReadyingProtectiveLight && Input.GetMouseButtonDown(0))
        {
            int i = 1;
            ProtectiveLightFriend();
            HeroAbilities.SelectingAttacker(i);
        }
        if (HeroAbilities.ReadyingAccusativeScroll && Input.GetMouseButtonDown(0))
        {
            int i = 1;
            AccusativeScrollEnemy();
            HeroAbilities.SelectingAttacker(i);
        }
        if (HeroAbilities.ReadyingStunningStrike && Input.GetMouseButtonDown(0))
        {
            int i = 1;
            StunningStrikeEnemy();
            HeroAbilities.SelectingAttacker(i);
        }
       


    }
   
   //CRUSADER ATTACKS
    private void SmiteEnemy()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            GameObject clickedObject = hit.collider.gameObject;
            Vector3 clickedPosition = hit.collider.transform.position;

            // Debug.Log("Clicked Object: " + clickedObject.name + " - Position: " + clickedPosition);
            HeroAbilities.Smite(clickedObject);
        }

    }
    private void ProtectiveLightFriend()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            GameObject clickedObject = hit.collider.gameObject;
            Vector3 clickedPosition = hit.collider.transform.position;

            // Debug.Log("Clicked Object: " + clickedObject.name + " - Position: " + clickedPosition);
            HeroAbilities.ProtectiveLight(clickedObject);
        }
    }
    private void AccusativeScrollEnemy()
    {
        if(enemyCubes[0] !=null && enemyCubes[1] != null)
        {
            Debug.Log("HIT BOTH ENEMIES");
            GameObject ClickedObject1, ClickedObject2;
            ClickedObject1 = enemyCubes[0];
            ClickedObject2 = enemyCubes[1];
            HeroAbilities.AccusativeScroll(ClickedObject1, ClickedObject2);
        }
        else if (enemyCubes[0] != null && enemyCubes[1] == null)
        {
            Debug.Log("HIT FIRST ENEMY");
            GameObject ClickedObject1, ClickedObject2;
            ClickedObject1 = enemyCubes[0];
            ClickedObject2 = null;
            HeroAbilities.AccusativeScroll(ClickedObject1, ClickedObject2);
        }
        else if (enemyCubes[0] == null && enemyCubes[1] != null)
        {

            Debug.Log("HIT SECOND ENEMY");
            GameObject ClickedObject1, ClickedObject2;
            ClickedObject1 = null;
            ClickedObject2 = enemyCubes[1];
            HeroAbilities.AccusativeScroll(ClickedObject1, ClickedObject2);
        }
        else
        {
            Debug.Log("BOTH ENEMIES ARE DEAD");
        }



           }


    
    private void StunningStrikeEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            GameObject clickedObject = hit.collider.gameObject;
            Vector3 clickedPosition = hit.collider.transform.position;

            // Debug.Log("Clicked Object: " + clickedObject.name + " - Position: " + clickedPosition);
            HeroAbilities.StunningStrike(clickedObject);
        }
    }
    //HWM ATTACKS

    //PLAGUE DOCTOR ATTACKS

    //OCCULTIST
}
