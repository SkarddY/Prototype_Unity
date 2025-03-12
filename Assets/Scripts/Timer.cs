using TMPro;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerText();
    }
    void UpdateTimerText() {
        int minutesElapsed = Mathf.FloorToInt(elapsedTime / 60);
        int secondsElapsed = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutesElapsed, secondsElapsed);
    }
}
