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
        //CRUSADER SUPPORT ABILITIES
       /* if (HeroAbilities.ReadyingProtectiveLight && Input.GetMouseButtonDown(0))
        {
            int i = 1;
            ProtectiveLightFriend();
            HeroAbilities.SelectingAttacker(i);
        }*/
    }
    //CRUSADER SUPPORT ABILITIES
    /*private void ProtectiveLightFriend()
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
    }*/
}
