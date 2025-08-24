using DialogueEditor;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScenarioData
{
    public GameObject panel;
    public GameObject checklist;
    public string type;
    public string correctNotification;
    public NPCConversation conversation;
    public string scenarioName;
    public string scenarioTime;
}