using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public int countdownTime = 5;          // 倒數秒數
    public GameObject teachUI;             // 教學介面
    public TMP_Text countdownText;         // 顯示倒數的文字
    public Button teachUI_closedButton;    // 關閉按鈕

    private int currentCountdown;          // 當前倒數值

    void OnEnable()
    {
        currentCountdown = countdownTime;  // 重置倒數
        teachUI_closedButton.interactable = false; // 禁用按鈕
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        while (currentCountdown > 0)
        {
            countdownText.text = currentCountdown.ToString();
            yield return new WaitForSeconds(1f);
            currentCountdown--;
        }

        // 倒數結束
        countdownText.text = "";
        teachUI_closedButton.interactable = true;
    }
}