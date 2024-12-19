using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueManager : MonoBehaviour
{
    public NPCConversation firstConversation;

    public void Start(){
        ConversationManager.Instance.StartConversation(firstConversation);
    }
}
