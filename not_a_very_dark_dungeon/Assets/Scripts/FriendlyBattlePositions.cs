using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBattlePositions : MonoBehaviour
{
    public HeroAbilities HeroAbilities;
    public GameObject[] friendlyCubePrefabs; // Array to store the friendly cube prefabs
    public Transform[] friendlyPositions; // Array to store the friendly positions
    private GameObject[] friendlyCubes; // Array to store the friendly cubes

    void Start()
    {
        friendlyCubes = new GameObject[friendlyPositions.Length];
        bool[] occupiedPositions = new bool[friendlyPositions.Length];

        for (int i = 0; i < friendlyPositions.Length; i++)
        {
            GameObject cubePrefab = friendlyCubePrefabs[i];
            GameObject cube = Instantiate(cubePrefab);

            int randomPositionIndex = GetRandomPositionIndex(occupiedPositions);
            cube.transform.position = friendlyPositions[randomPositionIndex].position;
            occupiedPositions[randomPositionIndex] = true;

            friendlyCubes[i] = cube;
        }
    }

    int GetRandomPositionIndex(bool[] occupiedPositions)
    {
        int randomIndex = Random.Range(0, friendlyPositions.Length);

        // Check if the random index is already occupied
        while (occupiedPositions[randomIndex])
        {
            randomIndex = Random.Range(0, friendlyPositions.Length);
        }

        return randomIndex;
    }


    void Update()
    {
       
        if (HeroAbilities.ReadyingBattleMedicine && Input.GetMouseButtonDown(0))
        {
            int i = 3;
            BattleMedicineFriend();
            HeroAbilities.SelectingAttacker(i);
        }

    }

    private void BattleMedicineFriend()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            GameObject clickedObject = hit.collider.gameObject;
            Vector3 clickedPosition = hit.collider.transform.position;

            HeroAbilities.BattleMedicine(clickedObject);
        }
    }
}
