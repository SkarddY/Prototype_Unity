using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnapScript: MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Transform> papers;
    public List<DragDrop> dragScript;
    public float snapRange = 0.5f;
    [SerializeField] Button finishButton;

    private Dictionary<Transform, Vector2> originalPositions = new Dictionary<Transform, Vector2>();
    private Dictionary<Transform, Transform> snappedPapers = new Dictionary<Transform, Transform>();

    void Start()
    {
        finishButton.gameObject.SetActive(false);

        foreach(DragDrop script in dragScript){
            script.dragStartedDelegate = StoreOriginalPos;
            script.dragEndedDelegate = SnapObject;
        }
    }
    
    //Store original position when dragging starts.
    void StoreOriginalPos(Transform obj){
        if(!originalPositions.ContainsKey(obj)){
            originalPositions[obj] = obj.position;
        }

    }

    public void SnapObject(Transform obj){
        foreach(Transform point in snapPoints){
            if (Vector2.Distance(point.position, obj.position) <= snapRange){
                //Check if tag matches.
                if(obj.CompareTag(point.tag)){
                    obj.position = point.position;
                    obj.rotation = Quaternion.Euler(0f,0f,0f);

                    snappedPapers[obj] = point;
                    CheckAllPapers();
                    return;
                }
            }
        }
        //If the snap is not valid, reset position.
        if(originalPositions.ContainsKey(obj)){
            obj.position = originalPositions[obj];
            snappedPapers.Remove(obj);
        }
    }

    void CheckAllPapers(){
        if (snappedPapers.Count < papers.Count){
            finishButton.gameObject.SetActive(false);
            return;
        }
        foreach (var pair in snappedPapers){
            Transform paper = pair.Key;
            Transform snapPoint = pair.Value;

            if (!paper.CompareTag(snapPoint.tag)){
                finishButton.gameObject.SetActive(false);
                return;
            }
        }
        finishButton.gameObject.SetActive(true);
    }

    public void EndMinigame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
