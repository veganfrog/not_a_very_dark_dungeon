using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TurnController : MonoBehaviour

{
    // Teams and members
    public List<GameObject> friendlyTeam;
    public List<GameObject> enemyTeam;
    public float turnDelay = 1.0f;

    public HeroAbilities heroAbilities;


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

                for (int j = startIndex; j < endIndex; j++)
                {
                    int randomIndex = Random.Range(j, endIndex);
                    GameObject temp = allMembers[j];
                    allMembers[j] = allMembers[randomIndex];
                    allMembers[randomIndex] = temp;
                }

                i = endIndex - 1;
            }
        }

        // Add members to turn order
        turnOrder.AddRange(allMembers);
        for(int i = 0; i < 8; i++)
        {
            Debug.Log(turnOrder[i]);
        }

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

                PerformAttack(member);
    
                // Wait for a short duration before the next turn
                yield return new WaitForSeconds(turnDelay);
            }
        }

        // Combat is over
        Debug.Log("Battle over!");
    }




    void PerformAttack(GameObject member)
    {
        Debug.Log("got here");
        int i;
        switch (member.tag)
        {
           
            case "Crusader":
                i = 1;
                heroAbilities.SelectingAttacker(i);
                break;
            case "HWM":
                 i = 2;
                heroAbilities.SelectingAttacker(i);
                break;
            case "PlagueDoctor":
                 i = 3;
                heroAbilities.SelectingAttacker(i);
                break;
            case "Occultist":
                 i = 4;
                heroAbilities.SelectingAttacker(i);
                break;
            case "BasicRat":
                break;
            case "DiseasedDog":
                break;
            case "Slime":
                break;
            case "PlagueRat":
                break;
            case "Hobo":
                break;

        }
   
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
