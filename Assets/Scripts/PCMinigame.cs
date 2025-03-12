using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class PCMinigame : MonoBehaviour
{
    private bool isFront, isRotatingLeft, isRotatingRight;
    public SnapCable snapCable;
    public float rotationSpeed = 100f, activationRange = 10f;
    [SerializeField] GameObject pCObject, cableObject, monitorObject;
    [SerializeField] GameObject leftButton, rightButton;
    [SerializeField] TextMeshProUGUI instructionTwoTxt, instructionThreeTxt;
    void Start()
    {
        isFront = true;
        AddEventTrigger(leftButton, EventTriggerType.PointerDown, () => isRotatingLeft = true);
        AddEventTrigger(leftButton, EventTriggerType.PointerUp, () => isRotatingLeft = false);
        AddEventTrigger(rightButton, EventTriggerType.PointerDown, () => isRotatingRight = true);
        AddEventTrigger(rightButton, EventTriggerType.PointerUp, () => isRotatingRight = false);
    }
    void Update()
    {
        if (snapCable.isConnected == true && isFront == true) {
            snapCable.powerButton.SetActive(true);
        } else snapCable.powerButton.SetActive(false);
         
        if (isRotatingLeft) {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (isRotatingRight) {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        CheckRotation();
    }
    void CheckRotation()
    {
        float yRotation = transform.eulerAngles.y;
        if (Mathf.Abs(yRotation - 180f) <= activationRange || Mathf.Abs(yRotation - (-180f)) <= activationRange)
        {
            cableObject.SetActive(true);
        } 
        else cableObject.SetActive(false);
    }

    void AddEventTrigger(GameObject obj, EventTriggerType type, UnityEngine.Events.UnityAction action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        if (trigger == null) {
            trigger = obj.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = type };
        entry.callback.AddListener((eventData) => action());
        trigger.triggers.Add(entry);
    }
    public void OnPowerButton() {
        if (snapCable.isConnected == true) {
            instructionTwoTxt.text = "<s> " + instructionTwoTxt.text + " </s>";
            Debug.Log("Encendiendo PC");
            pCObject.SetActive(false); monitorObject.SetActive(true);
        } else return;
    }
}
