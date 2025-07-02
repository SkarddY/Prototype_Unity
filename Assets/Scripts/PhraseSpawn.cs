using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class PhraseSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] phrasesText;
    [SerializeField] private Transform[] phraseSpawns;

    private Dictionary<GameObject, Vector3> spawnPositions = new Dictionary<GameObject, Vector3>();
    private List<Transform> availableSpawns = new();

    private IEnumerator Start()
    {
        if (phrasesText.Length > phraseSpawns.Length) {
            Debug.LogWarning("There are no spawn points or phrases assigned");
            yield break;
        }

        yield return null;

        availableSpawns = new List<Transform>(phraseSpawns);
        AssignSpawnPointsRandomly();
    }

    private void AssignSpawnPointsRandomly() {
        foreach (GameObject phrase in phrasesText) {
            int randomIndex = Random.Range(0, availableSpawns.Count);
            Transform chosenSpawn = availableSpawns[randomIndex];

            phrase.transform.position = chosenSpawn.position;
            phrase.transform.rotation = chosenSpawn.rotation;

            spawnPositions[phrase] = chosenSpawn.position;
            availableSpawns.RemoveAt(randomIndex);

            Debug.Log($"Assigned '{phrase.name}' to '{chosenSpawn.name}'");
        }
    }

    public void ResetPhrasePosition(GameObject phrase) {
        if (spawnPositions.TryGetValue(phrase, out Vector3 originalPosition))
        {
            phrase.transform.position = originalPosition;
        }
        else {
            Debug.LogWarning($"Phrase '{phrase.name}' has no assigned spawn position.");
        }
    }
}
