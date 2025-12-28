using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class trigger_teachUI : MonoBehaviour
{
    public GameObject hintUI;
    public Button button;
    public ButtonDelay buttonDelay; // 加這個！
    private bool canTrigger = true;

    public VideoPlayer videoPlayer;
    public GameObject RawImage;

    void Start()
    {
        hintUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("teachUI_point"))
        {
            if (canTrigger)
            {
                hintUI.SetActive(true);
                
                // 啟動按鈕延遲（不要直接設 interactable）
                if (buttonDelay != null)
                {
                    buttonDelay.StartButtonDelay();
                }
                
                canTrigger = false;
                RawImage.SetActive(true);
                videoPlayer.enabled = true;
                videoPlayer.Play();
            }
        }
    }
}