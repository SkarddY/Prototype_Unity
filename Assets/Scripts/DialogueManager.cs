using System.Collections;
using DialogueEditor;
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] NPCConversation[] Conversations;
    [SerializeField] GameObject[] Minigames;
    [SerializeField] GameObject DialogueCanva;
    
    public void Awake() {
        ConversationManager.Instance.StartConversation(Conversations[0]);
    }

    public void OnTutorialEnd() {
        StartCoroutine(TutorialEnd());
    }
    IEnumerator TutorialEnd() {
        DialogueCanva.SetActive(false);
        yield return new WaitForSeconds(1.25f);
        Conversations[0].gameObject.SetActive(false);
        ConversationManager.Instance.StartConversation(Conversations[2]);
        DialogueCanva.SetActive(true);
    }

    //PC RESTART MINIGAME SETTINGS
    public void OnRestartMinigame() {
        ConversationManager.Instance.EndConversation();
        DialogueCanva.SetActive(false);
        StartCoroutine(RestartMinigame());
    }
    IEnumerator RestartMinigame() {
        Debug.Log("Waiting to start minigame");
        yield return new WaitForSeconds(0.5f);
        Minigames[0].SetActive(true);
        Debug.Log("Minigame started");
    }
    public void OnRestartMinigameEnd() {
        StartCoroutine(RestartMinigameEnd());
    }
    IEnumerator RestartMinigameEnd() {
        yield return new WaitForSeconds(1.25f);
        Minigames[0].SetActive(false); DialogueCanva.SetActive(true);
        ConversationManager.Instance.StartConversation(Conversations[1]);
    }

    //FIRST MINIGAME START AND END SETTINGS
    public void OnFirstMinigameStart() {
        ConversationManager.Instance.EndConversation();
        DialogueCanva.SetActive(false);
        StartCoroutine(FirstMinigameStart());
    }
    IEnumerator FirstMinigameStart() {
        Debug.Log("Waiting to start Minigame");
        yield return new WaitForSeconds(1.25f);
        Minigames[1].SetActive(true);
        Debug.Log("Minigame started");
    }
    public void OnFirstMinigameEnd() { 
        DialogueCanva.SetActive(true);
        ConversationManager.Instance.StartConversation(Conversations[3]);
    }

    //SECOND MINIGAME START AND END SETTINGS
    public void OnSecondMinigameStart() {
        ConversationManager.Instance.EndConversation();
        DialogueCanva.SetActive(false);
        StartCoroutine(SecondMinigameStart());
    }
    IEnumerator SecondMinigameStart() {
        Debug.Log("Waiting to start minigame");
        yield return new WaitForSeconds(1.25f);
        Minigames[2].SetActive(true);
        Debug.Log("Second minigame started");
    }
    public void OnSecondMinigameEnd() {
        DialogueCanva.SetActive(true);
        ConversationManager.Instance.StartConversation(Conversations[4]);
    }

    //MESA DE AYUDA OPTION
    public void OnMesaDeAyudaOption() {
        ConversationManager.Instance.EndConversation();
        ConversationManager.Instance.StartConversation(Conversations[5]);
    }
} 

