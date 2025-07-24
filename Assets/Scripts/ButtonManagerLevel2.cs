using System.Collections;
using DialogueEditor;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonManagerLevel2 : MonoBehaviour
{
    [SerializeField] private ScenarioDataLevel2[] scenarioDataLevel2;
    [SerializeField] private Button activateButton;
    [SerializeField] private GameObject convoManager;
    [SerializeField] private Button[] notificationButtons;
    [SerializeField] private UnityEvent correctNotifEvent;
    [SerializeField] private TextMeshProUGUI incorrectMessageUI;

    private int selectedScenarioIndex = -1;
    private string correctNotificationID;
    void Start()
    {
        foreach (ScenarioDataLevel2 data in scenarioDataLevel2)
            data.panel.SetActive(false);

        convoManager.SetActive(false);
        activateButton.onClick.AddListener(ActivateRandomPanel);
    }

    void ActivateRandomPanel() {
        foreach (ScenarioDataLevel2 data in scenarioDataLevel2)
            data.panel.SetActive(false);

        selectedScenarioIndex = Random.Range(0, scenarioDataLevel2.Length);
        ScenarioDataLevel2 chosen = scenarioDataLevel2[selectedScenarioIndex];

        chosen.panel.SetActive(true);
        correctNotificationID = chosen.correctNotification;

        if (chosen.conversation != null && ConversationManager.Instance != null) { 
            ConversationManager.Instance.StartConversation(chosen.conversation);
            convoManager.SetActive(true);
        }

        SetupNotificationButtons();
        activateButton.interactable = false;
        activateButton.gameObject.SetActive(false);
    }

    void SetupNotificationButtons() {
        foreach (Button btn in notificationButtons) {
            string notifyOption = btn.name;

            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => ValidateNotificationChoice(notifyOption));
        }
    }

    void ValidateNotificationChoice(string selectedNotification) {
        if (selectedNotification == correctNotificationID) {
            Debug.Log("Correct notification selected: " + selectedNotification);
            correctNotifEvent.Invoke();
        }
        else
        {
            Debug.Log("Incorrect notification method");
            StartCoroutine(ShowIncorrectMessage());
        }
    }

    IEnumerator ShowIncorrectMessage() {
        if (incorrectMessageUI != null) { 
            incorrectMessageUI.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.25f);
            incorrectMessageUI.gameObject.SetActive(false);
        }
    }
}
