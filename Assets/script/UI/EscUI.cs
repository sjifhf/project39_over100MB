using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;

public class EscUI : MonoBehaviour
{
    public GameObject escUI_panel;
    public MouseLook mouseLook;

    VideoPlayer[] allVideos;
    List<VideoPlayer> pausedVideos = new List<VideoPlayer>();

    void Start()
    {
        escUI_panel.SetActive(false);
        Time.timeScale = 1f;
        allVideos = FindObjectsOfType<VideoPlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escUI_panel.activeSelf)
                CloseEscUI();
            else
                OpenEscUI();
        }
    }

    void OpenEscUI()
    {
        escUI_panel.SetActive(true);
        
        // 暫停遊戲
        Time.timeScale = 0f;
        
        // 暫停影片
        pausedVideos.Clear();
        foreach (var v in allVideos)
        {
            if (v.isPlaying)
            {
                v.Pause();
                pausedVideos.Add(v);
            }
        }
        
        // 關閉滑鼠視角控制
        if (mouseLook != null)
            mouseLook.SetLookEnabled(false);
        
        // 解鎖滑鼠
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseEscUI()
    {
        escUI_panel.SetActive(false);
        
        // 恢復遊戲
        Time.timeScale = 1f;
        
        // 恢復影片
        foreach (var v in pausedVideos)
        {
            v.Play();
        }
        
        // 恢復滑鼠視角控制
        if (mouseLook != null)
            mouseLook.SetLookEnabled(true);
    }

    public void ContinueGame()
    {
        Debug.Log("ContinueGame 被呼叫了！");
        CloseEscUI();
    }
}