using TMPro;
using UnityEngine;
public class PCMinigame : MonoBehaviour
{
    private bool isFront, isBack, isLeftSide, isRightSide;
    public SnapCable snapCable;
    [SerializeField] GameObject pcObject, cableObject;
    [SerializeField] TextMeshProUGUI instructionTwoTxt, instructionThreeTxt;
    void Start()
    {
        isFront = true;
        isBack = false; isLeftSide = false; isRightSide = false;
    }
    public void OnLeftButton() {
        if (isFront == true) {
            pcObject.transform.rotation = Quaternion.Euler(0,0,0);
            isFront = false;
            isRightSide = true;
        } else if (isRightSide == true) {
            pcObject.transform.rotation = Quaternion.Euler(0,-90,0);
            isRightSide = false;
            isBack = true;
            if (snapCable.isConnected == false) {
                cableObject.SetActive(true);
            } else cableObject.SetActive(false);
        } else if (isBack == true) {
            pcObject.transform.rotation = Quaternion.Euler(0,-180,0);
            isBack = false;
            isLeftSide = true;
        } else if (isLeftSide == true) {
            pcObject.transform.rotation = Quaternion.Euler(0,90,0);
            isLeftSide = false;
            isFront = true;
        } 
    }

    public void OnRightButton() {
        if (isFront == true) {
            pcObject.transform.rotation = Quaternion.Euler(0,180,0);
            isFront = false;
            isLeftSide = true;
        } else if (isLeftSide == true) {
            pcObject.transform.rotation = Quaternion.Euler(0,270,0);
            isLeftSide = false;
            isBack = true;
            if (snapCable.isConnected == false) {
                cableObject.SetActive(true);
            } else cableObject.SetActive(false);
        } else if (isBack == true) {
            pcObject.transform.rotation = Quaternion.Euler(0,360,0);
            isBack = false;
            isRightSide = true;
        } else if (isRightSide == true) {
            pcObject.transform.rotation = Quaternion.Euler(0,90,0);
            isRightSide = false;
            isFront = true;
        }
    }

    public void OnPowerButton() {
        if (snapCable.isConnected == true) {
            instructionTwoTxt.text = "<s> " + instructionTwoTxt.text + " </s>";
            Debug.Log("Encendiendo PC");
        } else return;
    }
}
