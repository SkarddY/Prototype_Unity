using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText, finalTimeText;
    private float elapsedTime;
    private bool gameEnded = false;

    void Update()
    {
        if(!gameEnded) {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }
    void UpdateTimerText() {
        int minutesElapsed = Mathf.FloorToInt(elapsedTime / 60);
        int secondsElapsed = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutesElapsed, secondsElapsed);
    }

    public void EndGame() {
        gameEnded = true;
        PlayerPrefs.SetFloat("FinalTime", elapsedTime);
        DisplayFinalTime();
    }
    void DisplayFinalTime() {
        float finalTime = PlayerPrefs.GetFloat("FinalTime");
        int minutesElapsed = Mathf.FloorToInt(finalTime / 60);
        int secondsElapsed = Mathf.FloorToInt(finalTime % 60);
        finalTimeText.text = string.Format("TIEMPO: {0:00}:{1:00}", minutesElapsed, secondsElapsed);
    }
    public void OnEndGameButton() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
