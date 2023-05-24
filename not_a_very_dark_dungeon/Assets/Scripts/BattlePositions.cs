using System.Collections;
using System.Collections.Generic;
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
        if (HeroAbilities.ReadyingSmite && Input.GetMouseButtonDown(0))
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
    }
}
