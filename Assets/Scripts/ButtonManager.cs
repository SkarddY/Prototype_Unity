using System.Collections;
using System.Collections.Generic;
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

    //End Checklist
    [SerializeField] private TextMeshProUGUI IncorrectGuess;
    [SerializeField] private TextMeshProUGUI IncorrectScalingTxt;
    [SerializeField] private UnityEvent correctGuessEvent;
    [SerializeField] private GameObject menorChecklist;
    [SerializeField] private GameObject moderadoChecklist;
    [SerializeField] private GameObject mayorChecklist;
    [SerializeField] private GameObject superiorChecklist;


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

        if (chosen.checklist != null)
        {
            PhraseOrderChecker checker = chosen.checklist.GetComponent<PhraseOrderChecker>();
            if (checker != null)
            {
                checker.InitializeScenario(chosen.scenarioName, chosen.scenarioTime);
            }
        }


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
        }
        else {
            StartCoroutine(IncorrectMessage());
            Debug.Log("Incorrect type selected: " + guessedType);
        }
    }

    public void ValidateNotificationByType(string buttonType) {
        if (buttonType == correctNotificationID)
        {
            Debug.Log("Correct Notification: " + buttonType);

            switch (buttonType)
            {
                case "Menor":
                    menorChecklist.SetActive(true);
                    break;
                case "Moderado":
                    moderadoChecklist.SetActive(true);
                    break;
                case "Mayor":
                    mayorChecklist.SetActive(true);
                    break;
                case "Superior":
                    superiorChecklist.SetActive(true);
                    break;
                default:
                    Debug.LogWarning("No GameObject: " + buttonType);
                    break;
            }
        }
        else {
            Debug.Log("Incorrect notification method, try again!");
            StartCoroutine(IncorrectScaling());
        }
    }

    public IEnumerator IncorrectMessage() {
        IncorrectGuess.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        IncorrectGuess.gameObject.SetActive(false);
    }

    private IEnumerator IncorrectScaling() { 
        IncorrectScalingTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        IncorrectScalingTxt.gameObject.SetActive(false);
    }
}
