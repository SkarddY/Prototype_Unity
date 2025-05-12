using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhraseSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] phrasesText;
    [SerializeField] Transform[] phraseSpawns;

    private Dictionary<GameObject, Vector3> spawnPositions = new Dictionary<GameObject, Vector3>(); 

    void Start()
    {
        if (phrasesText.Length > 0 && phraseSpawns.Length > 0) {
            SpawnPhrases();
        }
        else {
            Debug.LogWarning("There are no spawn points or phrases assigned");
        }
    }

    void SpawnPhrases()
    {
        int[] indices = { 0, 1, 2 };
        Shuffle(indices);

        for (int i = 0; i < phrasesText.Length; i++) {
            phrasesText[i].transform.position = phraseSpawns[indices[i]].position;
            phrasesText[i].transform.rotation = phraseSpawns[indices[i]].rotation;
            
            spawnPositions[phrasesText[i]] = phraseSpawns[indices[i]].position;
        }
    }

    void Shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--) {
            int randomIndex = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    public void ResetPhrasePosition(GameObject phrase) {
        if (spawnPositions.ContainsKey(phrase)) { 
            phrase.transform.position = spawnPositions[phrase];
        }
    }
}
