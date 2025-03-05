using System;
using System.Collections;
using DialogueEditor;
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] NPCConversation[] Conversations;
    [SerializeField] GameObject[] Minigames;
    public void Awake() {
        ConversationManager.Instance.StartConversation(Conversations[0]);
    }

    public void OnTutorialEnd() {
        Conversations[0].gameObject.SetActive(false);
        ConversationManager.Instance.StartConversation(Conversations[1]);
    }

    //FIRST MINIGAME START AND END SETTINGS
    public void OnFirstMinigameStart() {
        ConversationManager.Instance.EndConversation();
        StartCoroutine(FirstMinigameStart());
    }
    IEnumerator FirstMinigameStart() {
        Debug.Log("Waiting to start Minigame");
        yield return new WaitForSeconds(1.25f);
        Minigames[0].SetActive(true);
        Debug.Log("Minigame started");
    }
    public void OnFirstMinigameEnd() { 
        ConversationManager.Instance.StartConversation(Conversations[2]);
    }

    //SECOND MINIGAME START AND END SETTINGS
    public void OnSecondMinigameStart() {
        ConversationManager.Instance.EndConversation();
        StartCoroutine(SecondMinigameStart());
    }
    IEnumerator SecondMinigameStart() {
        Debug.Log("Waiting to start minigame");
        yield return new WaitForSeconds(1.25f);
        Minigames[1].SetActive(true);
        Debug.Log("Second minigame started");
    }
    public void OnSecondMinigameEnd() {
        ConversationManager.Instance.StartConversation(Conversations[3]);
    }

} 

