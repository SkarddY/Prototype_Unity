using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class SnapCable: MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<DragDropCable> dragCable;
    public GameObject cable, powerButton;
    public bool isConnected;
    [SerializeField] TextMeshProUGUI instructionOneText;
    public float snapRange = 0.5f;

    private Dictionary<Transform, Vector2> originalPositions = new Dictionary<Transform, Vector2>();
    private Dictionary<Transform, Transform> snappedCable = new Dictionary<Transform, Transform>();

    void Start()
    {
        powerButton.SetActive(false);
        isConnected = false;
        foreach(DragDropCable script in dragCable) {
            script.dragStartedDelegate = StoreOriginalPos;
            script.dragEndedDelegate = SnapObject;
        }
    } 
    //Store original position when dragging starts.
    void StoreOriginalPos(Transform obj) {
        if(!originalPositions.ContainsKey(obj)){
            originalPositions[obj] = obj.position;
        }
    }
    public void SnapObject(Transform obj) {
        foreach(Transform point in snapPoints){
            if (Vector2.Distance(point.position, obj.position) <= snapRange){
                //Check if tag matches.
                if(obj.CompareTag(point.tag)){
                    obj.position = point.position;
                    snappedCable[obj] = point;
                    instructionOneText.text = "<s> " + instructionOneText.text + " </s>";
                    isConnected = true;
                    cable.SetActive(false);
                    powerButton.SetActive(true);
                    return;
                }
            }
        }
        //If the snap is not valid, reset position.
        if(originalPositions.ContainsKey(obj)){
            obj.position = originalPositions[obj];
            snappedCable.Remove(obj);
        }
    }   
}
