using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhraseOrderChecker : MonoBehaviour
{
    public string phraseTag = "Phrase";
    public string positionTag = "PosSnap";
    public Button confirmButton;
    public TextMeshProUGUI resultMessage;
    public PhraseSpawn phraseSpawn;


    private List<GameObject> draggablePhrases = new List<GameObject>();
    private List<GameObject> correctPositions = new List<GameObject>();

    void Start() {
        resultMessage.text = "";
        draggablePhrases = GameObject.FindGameObjectsWithTag(phraseTag).OrderBy(obj => obj.name).ToList();
        correctPositions = GameObject.FindGameObjectsWithTag(positionTag).OrderBy(obj => obj.name).ToList();

        confirmButton.onClick.AddListener(CheckOrder);
    }

    private void CheckOrder() {
        bool isCorrect = true;

        for (int i = 0; i < draggablePhrases.Count; i++) {
            if (Vector3.Distance(draggablePhrases[i].transform.position, correctPositions[i].transform.position) > 0.1f) { 
                isCorrect = false; 
                break;
            }
        }
        if (isCorrect) {
            resultMessage.text = "El orden está correcto";
            resultMessage.color = Color.green;
            StartCoroutine(CorrectOrder());
        } else {
            resultMessage.text = "El orden es incorrecto, intenta de nuevo";
            resultMessage.color = Color.red;
            ResetPosition();
        }
    }

    IEnumerator CorrectOrder() {
        Debug.Log("Correct order");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(0);
    }

    private void ResetPosition() {
        if (phraseSpawn == null) return;

        foreach (var phrase in draggablePhrases) {
            phraseSpawn.ResetPhrasePosition(phrase);
        }
    }
}
