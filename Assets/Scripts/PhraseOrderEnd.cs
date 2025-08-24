using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PhraseOrderEnd: MonoBehaviour
{
    public string phraseTag = "Phrase";
    public string positionTag = "PosSnap";
    public Button confirmButton;
    public TextMeshProUGUI resultMessage;
    public PhraseSpawn phraseSpawn;
    [SerializeField] UnityEvent correctEndEvent;

    private List<GameObject> draggablePhrases = new List<GameObject>();
    private List<GameObject> correctPositions = new List<GameObject>();

    void Start()
    {
        if (correctEndEvent == null) correctEndEvent = new UnityEvent();
        correctEndEvent.AddListener(OnEventTriggered);

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
            correctEndEvent.Invoke();
        }
        
        else
        {
            resultMessage.text = "El orden está incorrecto";
            resultMessage.color = Color.red;
            ResetPosition();
        }
    }

    private void OnEventTriggered()
    {
        Debug.Log("Evento de orden correcto");
    }

    private void ResetPosition()
    {
        if (phraseSpawn == null) return;
        DragPhrases.ClearOccupiedPositions();

        foreach (var phrase in draggablePhrases)
        {
            phraseSpawn.ResetPhrasePosition(phrase);
        }
    }
}
