using TMPro;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeDisplay;
    public void ShowFinalTime() { 
        TimerManager.Instance.StopTimer();

        string finaltime = TimerManager.Instance.GetFormattedTime();
        timeDisplay.text = "Tu tiempo fue: " + finaltime; 
    }
}
