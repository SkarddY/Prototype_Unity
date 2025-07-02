using DialogueEditor;
using UnityEngine;

public class LevelConvoManager : MonoBehaviour
{
    [SerializeField] private NPCConversation thisLevelConvo;
    [SerializeField] private GameObject ConvoManager;

    private void Start() {
        ConvoManager.SetActive(false);
    }

    void OnEnable() {
        ConversationManager.Instance.StartConversation(thisLevelConvo);
    }
}
