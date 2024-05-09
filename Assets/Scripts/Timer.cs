using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float countDown = 301;
    void Update()
    {
        countDown -= Time.deltaTime;
        UpdateTimerUI();
        if (countDown < 1)
        {
            countDown = 0;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("DefeatMenu");
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = countDown.ToString();
        int minutes = Mathf.FloorToInt((countDown / 60));
        int seconds = Mathf.FloorToInt(countDown % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
