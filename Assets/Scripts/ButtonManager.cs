using System.Collections;
using DialogueEditor;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //This is to classify each scenario with a different type
    [SerializeField] private ScenarioData[] scenarioData;
    [SerializeField] private Button[] typeButton;
    private int selectedScenarioIndex = -1;
    private string currentScenarioType;
    
    //This is for the random scenario selection when pressing start
    [SerializeField] private GameObject[] scenariosPanels;
    [SerializeField] private Button activateButton;
    
    //This is for starting the conversation linked to each scenario
    [SerializeField] private GameObject convoManager;
    [SerializeField] private NPCConversation[] scenarioConvos;

    //This is for continuing to the next stage after guessing correctly the type
    [SerializeField] private TextMeshProUGUI IncorrectGuess;
    [SerializeField] private UnityEvent correctGuessEvent;
    [SerializeField] private Button[] notificationButtons;
    [SerializeField] private UnityEvent correctNotifEvent;

    void Start() {
        foreach (ScenarioData data in scenarioData)
            data.panel.SetActive(false);

        convoManager.SetActive(false);
        activateButton.onClick.AddListener(ActivateRandomPanel);

        foreach (Button btn in typeButton) {
            string guessedType = btn.name;
            btn.onClick.AddListener(() => ValidateTypeGuess(guessedType));
        }
    }
    
    private string correctNotificationID;
    void ActivateRandomPanel() {
        foreach (ScenarioData data in scenarioData)
            data.panel.SetActive(false);

        selectedScenarioIndex = Random.Range(0, scenarioData.Length);
        ScenarioData chosen = scenarioData[selectedScenarioIndex];

        chosen.panel.SetActive(true);
        currentScenarioType = chosen.type;
        correctNotificationID = chosen.correctNotification;

        if (chosen.conversation != null && ConversationManager.Instance != null)
        {
            ConversationManager.Instance.StartConversation(chosen.conversation);
            convoManager.SetActive(true);
        }
    }

    void ValidateTypeGuess(string guessedType) {
        if (guessedType == currentScenarioType)
        {
            Debug.Log("Correct type selected: " + guessedType);
            
            correctGuessEvent.Invoke();
            SetupNotificationButtons();
        }
        else {
            StartCoroutine(IncorrectMessage());
            Debug.Log("Incorrect type selected: " + guessedType);
        }
    }

    void SetupNotificationButtons() {
        foreach (Button btn in notificationButtons) {
            string notifyOption = btn.name;

            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => ValidateTypeGuess(notifyOption));

            correctNotifEvent.Invoke();
        }
    }
    IEnumerator IncorrectMessage() {
        IncorrectGuess.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        IncorrectGuess.gameObject.SetActive(false);
    }
}
