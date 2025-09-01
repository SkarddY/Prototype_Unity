using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PhraseOrderChecker : MonoBehaviour
{
    public string phraseTag = "Phrase";
    public string positionTag = "PosSnap";
    public Button confirmButton;
    public GameObject endMessagePanel;
    public TextMeshProUGUI resultMessage;
    public PhraseSpawn phraseSpawn;
    [SerializeField] UnityEvent correctEndEvent;

    //Correct message depending on scenario and type.
    public string scenarioID;
    public string scenarioTime; 

    private List<GameObject> draggablePhrases = new List<GameObject>();
    private List<GameObject> correctPositions = new List<GameObject>();

    void Start() {
        if (correctEndEvent == null) correctEndEvent = new UnityEvent();
        correctEndEvent.AddListener(OnEventTriggered);

        endMessagePanel.gameObject.SetActive(false);
        resultMessage.text = "";
        draggablePhrases = GameObject.FindGameObjectsWithTag(phraseTag).OrderBy(obj => obj.name).ToList();
        correctPositions = GameObject.FindGameObjectsWithTag(positionTag).OrderBy(obj => obj.name).ToList();

        confirmButton.onClick.AddListener(CheckOrder);
    }

    private void CheckOrder()
    {
        bool isCorrect = true;

        foreach (GameObject phrase in draggablePhrases)
        {
            Transform snappedTo = phrase.transform;
            string phraseID = phrase.name.Replace("Phrase", "");

            GameObject slot = correctPositions.FirstOrDefault(pos =>
                        Vector3.Distance(phrase.transform.position, pos.transform.position) < 0.1f
                        );
            if (slot == null || !slot.name.Contains(phraseID))
            {
                isCorrect = false; break;
            }
        }

        if (isCorrect)
        {
            endMessagePanel.gameObject.SetActive(true);
            string messageToShow = $"¡Correcto! al parecer era un problema de {scenarioID} y la solución tomará {scenarioTime}";
            resultMessage.text = messageToShow;
            resultMessage.color = Color.green;
            StartCoroutine(correctOrder());
        }
        else
        {
            StartCoroutine(ErrorMessage());
            ResetPosition();
        }
    }

    private void OnEventTriggered() {
        Debug.Log("Evento de orden correcto");
    }

    private void ResetPosition() {
        if (phraseSpawn == null) return;
        DragPhrases.ClearOccupiedPositions();

        foreach (var phrase in draggablePhrases) {
            phraseSpawn.ResetPhrasePosition(phrase);
        }
    }

    private IEnumerator ErrorMessage() { 
        endMessagePanel.SetActive(true);
        resultMessage.text = "El orden está incorrecto, intenta nuevamente";
        resultMessage.color = Color.red;
        yield return new WaitForSeconds(2.15f);
        endMessagePanel.SetActive(false);
        resultMessage.text = " ";
    }

    private IEnumerator correctOrder() {
        yield return new WaitForSeconds(5.25f);
        correctEndEvent.Invoke();
    }

    public void InitializeScenario(string id, string type) { 
        scenarioID = id;
        scenarioTime = type;
    }
}
