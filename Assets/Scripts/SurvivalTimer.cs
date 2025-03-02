using UnityEngine;
using TMPro;

public class SurvivalTimer : MonoBehaviour
{
    public TextMeshProUGUI survivalTimeText;
    private float elapsedTime = 0f;
    private bool isRunning = true;

    void Start()
    {
        if (survivalTimeText == null)
        {
            survivalTimeText = GameObject.Find("SurvivalTime").GetComponent<TextMeshProUGUI>();
        }

        if (survivalTimeText != null)
        {
            survivalTimeText.text = "00:00:000";
        }
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);

        if (survivalTimeText != null)
        {
            survivalTimeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
    }

    // Call this if you want to stop the timer
    public void StopTimer()
    {
        isRunning = false;
    }

    // Call this if you want to resume the timer after stopping
    public void StartTimer()
    {
        isRunning = true;
    }
}
