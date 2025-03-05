using DialogueEditor;
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] NPCConversation[] Conversations;
    public void Awake() {
        ConversationManager.Instance.StartConversation(Conversations[0]);
    }

    public void OnTutorialEnd() {
        Conversations[0].gameObject.SetActive(false);
        ConversationManager.Instance.StartConversation(Conversations[1]);
    }

    public void OnFirstMinigameEnd() { 
        ConversationManager.Instance.EndConversation();
        ConversationManager.Instance.StartConversation(Conversations[2]);
    }
} 

