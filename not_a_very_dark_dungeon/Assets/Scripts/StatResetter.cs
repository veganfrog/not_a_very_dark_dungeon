using UnityEngine;

public class StatResetter : MonoBehaviour
{
    public GameObject[] friendlyCubePrefabs; // Array to store the friendly cube prefabs
    public GameObject[] enemyCubePrefabs; // Array to store the enemy cube prefabs

    public void ResetCubeStats()
    {
        foreach (GameObject prefab in friendlyCubePrefabs)
        {
            // Reset the stats of the friendly cube prefab
            ResetCubeStats(prefab);
        }

        foreach (GameObject prefab in enemyCubePrefabs)
        {
            // Reset the stats of the enemy cube prefab
            ResetCubeStats(prefab);
        }
    }

    private void ResetCubeStats(GameObject cubePrefab)
    {
        // Reset the stats of the cube prefab
        // Replace this with your own logic to reset the cube's stats
        Stats cubeStats = cubePrefab.GetComponent<Stats>();
        if (cubeStats != null)
        {
            cubeStats.Health = cubeStats.MaxHealth;
            cubeStats.IsStunned = false;
        }
    }

    // Example usage
    private void Start()
    {
        // Call the ResetCubeStats() method at the start to reset the cube stats
        ResetCubeStats();
    }
}