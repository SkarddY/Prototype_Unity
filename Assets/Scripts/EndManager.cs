using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeDisplay;
    public void ShowFinalTime() { 
        TimerManager.Instance.StopTimer();

        string finaltime = TimerManager.Instance.GetFormattedTime();
        timeDisplay.text = "Tu tiempo fue: " + finaltime; 
    }
    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
    }
}
