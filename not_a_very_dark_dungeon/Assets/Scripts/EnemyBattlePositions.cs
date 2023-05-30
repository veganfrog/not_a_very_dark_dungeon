using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBattlePositions : MonoBehaviour
{
    public HeroAbilities HeroAbilities;
    public GameObject[] enemyCubePrefabs;
    public Transform[] enemyPositions;
    private GameObject[] enemyCubes;


    void Start()
    {
        enemyCubes = new GameObject[enemyPositions.Length];
        bool[] occupiedPositions = new bool[enemyPositions.Length];

        for (int i = 0; i < enemyPositions.Length; i++)
        {
            GameObject cubePrefab = enemyCubePrefabs[i];
            GameObject cube = Instantiate(cubePrefab);

            int randomPositionIndex = GetRandomPositionIndex(occupiedPositions);
            cube.transform.position = enemyPositions[randomPositionIndex].position;
            occupiedPositions[randomPositionIndex] = true;

            enemyCubes[i] = cube;
        }
    }

    int GetRandomPositionIndex(bool[] occupiedPositions)
    {
        int randomIndex = Random.Range(0, enemyPositions.Length);

        // Check if the random index is already occupied
        while (occupiedPositions[randomIndex])
        {
            randomIndex = Random.Range(0, enemyPositions.Length);
        }

        return randomIndex;
    }

    // Update is called once per frame
    void Update()
    {
        //Crusader
        if (HeroAbilities.ReadyingSmite && Input.GetMouseButtonDown(0))
        {
            int i = 1;
            SmiteEnemy();
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
        //HWM
        if (HeroAbilities.ReadyingPistolShot && Input.GetMouseButtonDown(0))
        {
            int i = 2;
            PistolShotEnemy();
            HeroAbilities.SelectingAttacker(i);
        }
        if (HeroAbilities.ReadyingGrapeshotBlast && Input.GetMouseButtonDown(0))
        {
            int i = 2;
            GrapeshotBlastEnemy();
            HeroAbilities.SelectingAttacker(i);
        }
        if (HeroAbilities.ReadyingSlash && Input.GetMouseButtonDown(0))
        {
            int i = 2;
            SlashEnemy();
            HeroAbilities.SelectingAttacker(i);
        }
        //Plague
        if (HeroAbilities.ReadyingPistolShot && Input.GetMouseButtonDown(0))
        {
            int i = 3;
           StunningBombEnemy();
            HeroAbilities.SelectingAttacker(i);
        }
        if (HeroAbilities.ReadyingGrapeshotBlast && Input.GetMouseButtonDown(0))
        {
            int i = 3;
            PlagueBombEnemy();
            HeroAbilities.SelectingAttacker(i);
        }
        

    }
    //CRUSADER ABILITIES
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
    private void AccusativeScrollEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            GameObject clickedObject = hit.collider.gameObject;
            Vector3 clickedPosition = hit.collider.transform.position;

            if (enemyCubes[0] != null && enemyCubes[1] != null)
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
    //HWM ABILITIES
    private void PistolShotEnemy()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            GameObject clickedObject = hit.collider.gameObject;
            Vector3 clickedPosition = hit.collider.transform.position;

            // Debug.Log("Clicked Object: " + clickedObject.name + " - Position: " + clickedPosition);
            HeroAbilities.PistolShot(clickedObject);
        }

    }
    private void GrapeshotBlastEnemy()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            GameObject clickedObject = hit.collider.gameObject;
            Vector3 clickedPosition = hit.collider.transform.position;

            if (enemyCubes[0] != null && enemyCubes[1] != null && enemyCubes[2] != null)
            {
                Debug.Log("HIT ALL ENEMIES");
                GameObject ClickedObject1, ClickedObject2, ClickedObject3;
                ClickedObject1 = enemyCubes[0];
                ClickedObject2 = enemyCubes[1];
                ClickedObject3 = enemyCubes[2];
                HeroAbilities.GrapeshotBlast(ClickedObject1, ClickedObject2, ClickedObject3);
            }
            else if (enemyCubes[0] != null && enemyCubes[1] == null && enemyCubes[2] != null)
            {

                GameObject ClickedObject1, ClickedObject2, ClickedObject3;
                ClickedObject1 = enemyCubes[0];
                ClickedObject2 = enemyCubes[1];
                ClickedObject3 = null;
                HeroAbilities.GrapeshotBlast(ClickedObject1, ClickedObject2, ClickedObject3);
            }
            else if (enemyCubes[0] != null && enemyCubes[1] != null && enemyCubes[2] == null)
            {

                GameObject ClickedObject1, ClickedObject2, ClickedObject3;
                ClickedObject1 = enemyCubes[0];
                ClickedObject2 = null;
                ClickedObject3 = enemyCubes[2];
                HeroAbilities.GrapeshotBlast(ClickedObject1, ClickedObject2, ClickedObject3);
            }
            else if (enemyCubes[0] == null && enemyCubes[1] != null && enemyCubes[2] != null)
            {
                GameObject ClickedObject1, ClickedObject2, ClickedObject3;
                ClickedObject1 = null;
                ClickedObject2 = enemyCubes[1];
                ClickedObject3 = enemyCubes[2];
                HeroAbilities.GrapeshotBlast(ClickedObject1, ClickedObject2, ClickedObject3);
            }
            else if (enemyCubes[0] != null && enemyCubes[1] == null && enemyCubes[2] == null)
            {

                GameObject ClickedObject1, ClickedObject2, ClickedObject3;
                ClickedObject1 = enemyCubes[0];
                ClickedObject2 = null;
                ClickedObject3 = null;
                HeroAbilities.GrapeshotBlast(ClickedObject1, ClickedObject2, ClickedObject3);
            }
            else if (enemyCubes[0] == null && enemyCubes[1] != null && enemyCubes[2] == null)
            {

                GameObject ClickedObject1, ClickedObject2, ClickedObject3;
                ClickedObject1 = null;
                ClickedObject2 = enemyCubes[1];
                ClickedObject3 = null;
                HeroAbilities.GrapeshotBlast(ClickedObject1, ClickedObject2, ClickedObject3);
            }
            else if (enemyCubes[0] == null && enemyCubes[1] == null && enemyCubes[2] != null)
            {

                GameObject ClickedObject1, ClickedObject2, ClickedObject3;
                ClickedObject1 = null;
                ClickedObject2 = null;
                ClickedObject3 = enemyCubes[2];
                HeroAbilities.GrapeshotBlast(ClickedObject1, ClickedObject2, ClickedObject3);
            }
            else
                Debug.Log("Everyone is dead");
        }





    }
    private void SlashEnemy()
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
    // Plague Doctor
    private void StunningBombEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            GameObject clickedObject = hit.collider.gameObject;
            Vector3 clickedPosition = hit.collider.transform.position;


            HeroAbilities.StunningBomb(clickedObject);
        }
    }
    private void PlagueBombEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            GameObject clickedObject = hit.collider.gameObject;
            Vector3 clickedPosition = hit.collider.transform.position;


            HeroAbilities.PlagueBomb(clickedObject);
        }
    }
}
