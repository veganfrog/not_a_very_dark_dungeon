using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TurnController : MonoBehaviour

{// TDDO : MKE IT SO THAT ONLY ONE PERSON IS READY.
    // Teams and members
    public List<GameObject> friendlyTeam;
    public List<GameObject> enemyTeam;
    public float turnDelay = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        // Determine initial turn order
        List<GameObject> turnOrder = DetermineTurnOrder(friendlyTeam, enemyTeam);

        // Start combat
        StartCombat(turnOrder);
    }

    List<GameObject> DetermineTurnOrder(List<GameObject> friendlyTeam, List<GameObject> enemyTeam)
    {
        List<GameObject> turnOrder = new List<GameObject>();

        // Combine both teams
        List<GameObject> allMembers = new List<GameObject>(friendlyTeam);
        allMembers.AddRange(enemyTeam);

        // Sort members based on speed
        allMembers.Sort((a, b) => GetSpeed(b) - GetSpeed(a));

        // If there are members with the same speed, shuffle their order randomly
        for (int i = 0; i < allMembers.Count - 1; i++)
        {
            if (GetSpeed(allMembers[i]) == GetSpeed(allMembers[i + 1]))
            {
                int startIndex = i;
                int endIndex = i + 1;
                while (endIndex < allMembers.Count && GetSpeed(allMembers[startIndex]) == GetSpeed(allMembers[endIndex]))
                {
                    endIndex++;
                }

                // Shuffle members within the speed group
                for (int j = startIndex; j < endIndex; j++)
                {
                    int randomIndex = Random.Range(j, endIndex);
                    GameObject temp = allMembers[j];
                    allMembers[j] = allMembers[randomIndex];
                    allMembers[randomIndex] = temp;
                }

                // Skip the shuffled members
                i = endIndex - 1;
            }
        }

        // Add members to turn order
        turnOrder.AddRange(allMembers);

        return turnOrder;
    }

    int GetSpeed(GameObject member)
    {
        // Retrieve speed stat from Stats script attached to member object
        Stats stats = member.GetComponent<Stats>();
        if (stats != null)
        {
            return stats.Speed;
        }
        return 0;
    }

    IEnumerator StartCombat(List<GameObject> turnOrder)
    {
        // Main combat loop
        while (!IsBattleOver())
        {
            foreach (GameObject member in turnOrder)
            {
                // Skip if the member is already defeated
                Stats stats = member.GetComponent<Stats>();
                if (stats != null && stats.Health <= 0)
                {
                    continue;
                }

                // Perform attack
                if (member.tag == "Friendly")
                {
                    // Select a random enemy target
                    GameObject target = enemyTeam[Random.Range(0, enemyTeam.Count)];
                    PerformAttack(member, target);
                }
                else if (member.tag == "Enemy")
                {
                    // Select a random friendly target
                    GameObject target = friendlyTeam[Random.Range(0, friendlyTeam.Count)];
                    PerformAttack(member, target);
                }

                // Wait for a short duration before the next turn
                yield return new WaitForSeconds(turnDelay);
            }
        }

        // Combat is over
        Debug.Log("Battle over!");
    }




    void PerformAttack(GameObject attacker, GameObject defender)
    {
      /*  Debug.Log(attacker.name + " attacks " + defender.name);

        // Retrieve attack and defense stats from Stats script attached to member objects
        Stats attackerStats = attacker.GetComponent<Stats>();
        Stats defenderStats = defender.GetComponent<Stats>();

        // Calculate damage
        int damage = attackerStats.attack - defenderStats.defense;
        if (damage < 0)
        {
            damage = 0;
        }

        // Apply damage to defender
        defenderStats.health -= damage;
        if (defenderStats.health < 0)
        {
            defenderStats.health = 0;
        }

        // Print attack result
        Debug.Log(defender.name + " takes " + damage + " damage!");
        Debug.Log(defender.name + "'s health: " + defenderStats.health);
      */
    }

    bool IsBattleOver()
    {
        // Check if any team has no remaining members
        if (friendlyTeam.Count == 0 || enemyTeam.Count == 0)
        {
            return true;
        }
        return false;
    }
}
