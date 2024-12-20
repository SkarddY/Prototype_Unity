using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueManager : MonoBehaviour
{
    public NPCConversation[] Conversations;
    public void Start(){
        ConversationManager.Instance.StartConversation(Conversations[0]);
    }
    public void OnLoggedIn(){
        ConversationManager.Instance.StartConversation(Conversations[1]);
    }

    public void OnInternetConnection(){
        StartCoroutine(InternetConnection());
    }

    IEnumerator InternetConnection(){
        yield return new WaitForSeconds(1.5f);
        ConversationManager.Instance.StartConversation(Conversations[2]);
    }
}
