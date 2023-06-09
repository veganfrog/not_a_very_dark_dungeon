using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TurnController : MonoBehaviour
{
    public Stats stats;
    public HeroAbilities heroAbilities;
    public EnemyAbilities enemyAbilities;
    public GameOver gameOver;
    // Define the teams and their members
    public List<GameObject> team1;
    public List<GameObject> team2;
    public bool IsReady = false;

    // Start the battle
    private void Start()
    {
        StartCoroutine(StartBattle());
    }

    // Coroutine to handle the turn-based battle
    private System.Collections.IEnumerator StartBattle()
    {
        yield return new WaitForSeconds(3.0f);

        // Combine all characters from both teams into a single list
        List<GameObject> allCharacters = new List<GameObject>();
        allCharacters.AddRange(team1);
        allCharacters.AddRange(team2);

        // Sort the characters in descending order of speed
        allCharacters.Sort((a, b) => b.GetComponent<Stats>().Speed.CompareTo(a.GetComponent<Stats>().Speed));

        // Log the turn list into the console
        LogTurnList(allCharacters);

        // Loop until one team has no remaining characters
        while (team1.Count > 0 && team2.Count > 0)
        {
            

            // Handle the turn for each character
            for (int i = 0; i < allCharacters.Count; i++)
            {
                GameObject currentCharacter = allCharacters[i];

                if (!IsAlive(currentCharacter))
                    continue;

                List<GameObject> targetTeam = (team1.Contains(currentCharacter)) ? team2 : team1;

                GameObject target = targetTeam[Random.Range(0, targetTeam.Count)];

                if (currentCharacter.GetComponent<Stats>().BleedDamage > 0 || currentCharacter.GetComponent<Stats>().PoisonDamage > 0)
                {
                    stats.DOTDamage(currentCharacter);
                }
                if (currentCharacter.GetComponent<Stats>().IsStunned == true)
                {
                    stats.IsStunned = false;
                    Debug.Log("Skipped turn");
                    goto amongus;
                    
                }
                // Set the readiness boolean for the current character
                SetReadiness(currentCharacter);

                

                // Attack the target

                // Wait until the character finishes attacking
                while (!IsReady)
                {
                    yield return null;
                }
                IsReady = false;
                amongus:

                // Check if the target is defeated
                if (!IsAlive(target))
                    targetTeam.Remove(target);


            }
        }
        if(team1.Count == 0)
        {
            gameOver.IsGameOver();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }



        // The battle has ended
        Debug.Log("Battle Over!");
    }
    public void ReadyUp()
    {
        IsReady = true;
    }

    private void LogTurnList(List<GameObject> turnList)
    {
        Debug.Log("Turn List:");
        foreach (GameObject character in turnList)
        {
            string characterName = character.GetComponent<Stats>().Name;
            Debug.Log(characterName);
        }
    }

    public bool IsAlive(GameObject character)
    {
        Stats stats = character.GetComponent<Stats>();
        return stats != null && stats.Health > 0;
    }
    private void SetReadiness(GameObject character)
    {
        float randomNumber = Random.Range(1,3);
        int i;
        switch (character.tag)
        {
            case "Crusader":
                i = 1;
                heroAbilities.SelectingAttacker(i);
                Debug.Log("READIED CRUSADER");
                break;
            case "HWM":
                i = 2;
                heroAbilities.SelectingAttacker(i);
                Debug.Log("READIED HWM");
                break;
            case "Plague Doctor":
                i = 3;
                heroAbilities.SelectingAttacker(i);
                Debug.Log("READIED PD");
                break;
            case "BasicRat":
                Debug.Log("READIED RAT");
                enemyAbilities.RatBite();
                break;
            case "DiseasedDog":
                Debug.Log("READIED DOG");
                enemyAbilities.RabidBite();
                break;
            case "Slime":
                Debug.Log("READIED SLIME");
                enemyAbilities.SlimeBash();
                break;
            case "PlagueRat":
                Debug.Log("READIED PLAGUE RAT");
                enemyAbilities.DiseasedSpit();
                break;
            case "Hobo":
                switch (randomNumber)
                {
                    case 1:
                        enemyAbilities.Shank();
                        break;
                   case 2:
                        enemyAbilities.Bash();
                        break;
                        case 3:
                        enemyAbilities.Spit();
                        break;
                }
                Debug.Log("READIED HOBO");
                break;
        }
    }
}
