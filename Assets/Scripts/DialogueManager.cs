using DialogueEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using DialogueEditor;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] NPCConversation[] Conversations;
    /*public void Awake(){
        ConversationManager.Instance.StartConversation(Conversations[0]);
    }*/

    //BUTTONS FOR CONVERSATION CHANGES
    /*public void OnStartGame() {
        ConversationManager.Instance.StartConversation(Conversations[0]);      
    } */
    public void OnFinishedIntro(){
        ConversationManager.Instance.StartConversation(Conversations[1]);
    }
}
