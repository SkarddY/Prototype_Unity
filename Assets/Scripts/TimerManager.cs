using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance {  get; private set; }

    private float elapsedTime = 0f;
    private bool isRunning = true;

    [SerializeField] private TextMeshProUGUI liveTimer;

    private void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Update() {
        if (isRunning) {
            elapsedTime += Time.deltaTime;

            if (liveTimer != null)
                liveTimer.text = GetFormattedTime();
        }
    }
    public void StopTimer() => isRunning = false;
    public string GetFormattedTime() { 
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}
