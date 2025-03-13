using System.Collections;
using DialogueEditor;
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] NPCConversation[] Conversations;
    [SerializeField] GameObject[] Minigames;
    [SerializeField] GameObject dialogueCanva, endGameCanva;
    
    void Start() {
        ConversationManager.Instance.StartConversation(Conversations[0]);
    }

    public void OnTutorialEnd() {
        StartCoroutine(TutorialEnd());
    }
    IEnumerator TutorialEnd() {
        ConversationManager.Instance.EndConversation();
        dialogueCanva.SetActive(false);
        yield return new WaitForSeconds(1.25f);
        ConversationManager.Instance.StartConversation(Conversations[2]);
        dialogueCanva.SetActive(true);
    }

    //PC RESTART MINIGAME SETTINGS
    public void OnRestartMinigame() {
        ConversationManager.Instance.EndConversation();
        dialogueCanva.SetActive(false);
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
        Minigames[0].SetActive(false); dialogueCanva.SetActive(true);
        ConversationManager.Instance.StartConversation(Conversations[1]);
    }

    //FIRST MINIGAME START AND END SETTINGS
    public void OnFirstMinigameStart() {
        ConversationManager.Instance.EndConversation();
        dialogueCanva.SetActive(false);
        StartCoroutine(FirstMinigameStart());
    }
    IEnumerator FirstMinigameStart() {
        Debug.Log("Waiting to start Minigame");
        yield return new WaitForSeconds(1.25f);
        Minigames[1].SetActive(true);
        Debug.Log("Minigame started");
    }
    public void OnFirstMinigameEnd() { 
        dialogueCanva.SetActive(true);
        ConversationManager.Instance.StartConversation(Conversations[3]);
    }

    //SECOND MINIGAME START AND END SETTINGS
    public void OnSecondMinigameStart() {
        ConversationManager.Instance.EndConversation();
        dialogueCanva.SetActive(false);
        StartCoroutine(SecondMinigameStart());
    }
    IEnumerator SecondMinigameStart() {
        Debug.Log("Waiting to start minigame");
        yield return new WaitForSeconds(1.25f);
        Minigames[2].SetActive(true);
        Debug.Log("Second minigame started");
    }
    public void OnSecondMinigameEnd() {
        dialogueCanva.SetActive(true);
        ConversationManager.Instance.StartConversation(Conversations[4]);
    }

    //MESA DE AYUDA OPTION
    public void OnMesaDeAyudaOption() {
        ConversationManager.Instance.EndConversation();
        ConversationManager.Instance.StartConversation(Conversations[5]);
    }

    //END GAME
    public void OnGameEnd() {
        ConversationManager.Instance.EndConversation();
        dialogueCanva.SetActive(false);
        endGameCanva.SetActive(true);
    }

} 


