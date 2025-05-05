using DialogueEditor;
using UnityEngine;

public class LevelConvoManager : MonoBehaviour
{
    [SerializeField] NPCConversation thisLevelConvo;
    void Start() {
         ConversationManager.Instance.StartConversation(thisLevelConvo);
    }
}
