using System.Collections.Generic;
using UnityEngine;

public class PaperSpawn : MonoBehaviour
{
    public GameObject paperPrefab;
    public List<Sprite> zoneOne, zoneTwo, zoneThree;
    public Transform[] spawnPoints;

    private string[] tags = {"PaperZone00", "PaperZone01", "PaperZone02"};

    void Start()
    {
        SpawnPapers();
    }

    void SpawnPapers(){
        for (int i = 0; i < 10; i++){
            GameObject newPaper = Instantiate(paperPrefab);

            DragDrop dragScript = newPaper.GetComponent<DragDrop>();
            if (dragScript == null){
                dragScript = newPaper.AddComponent<DragDrop>();
            }

            string randomTag = tags[Random.Range(0, tags.Length)];
            newPaper.tag = randomTag;

            SpriteRenderer sr = newPaper.GetComponent<SpriteRenderer>();
            if (randomTag == "PaperZone00") sr.sprite = zoneOne[0];
            if (randomTag == "PaperZone01") sr.sprite = zoneTwo[0];
            if (randomTag == "PaperZone02") sr.sprite = zoneThree[0];

            Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
            newPaper.transform.position = randomSpawn.position;

            newPaper.SetActive(true);
        }

    }

}
