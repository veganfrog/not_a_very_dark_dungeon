using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EventTrigger : MonoBehaviour
{
    public GameObject promptPanel;
    public Text promptText;
    private bool isPromptActive = false;
    private bool hasGuessed = false;
    private bool isGuessCorrect = false;

    private void Start()
    {
        promptPanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.transform.CompareTag("Player") && !isPromptActive)
        {
            promptPanel.SetActive(true);
            isPromptActive = true;
        }
    }
    public void MakeGuess(int guess)
    {
        if (isPromptActive && !hasGuessed)
        {
            hasGuessed = true;
            int result = Random.Range(0, 2);
            isGuessCorrect = (guess == result);
            if (isGuessCorrect)
            {
                promptText.text = "NICEEEEEE";
            }
            else
            {
                promptText.text = "YOU DIDN'T GUESS CORRECTLY";
                //TODO remove 20% of players health
            }
        }
    }
    public void ClosePrompt()
    {
        if (isPromptActive && hasGuessed)
        {
            promptPanel.SetActive(false);
            isPromptActive = false;
            hasGuessed = false;
            isGuessCorrect = false;
        }
    }

}
