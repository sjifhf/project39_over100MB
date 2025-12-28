using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationchanging : MonoBehaviour
{
    public float turningspeed = 180f; // 可調整速度
    int finalrotation = 0;
    
    [HideInInspector]
    public bool isRotating = false; // 是否正在旋轉

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            finalrotation += 90;
            isRotating = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            finalrotation -= 90;
            isRotating = true;
        }
        
        Quaternion targetrotation = Quaternion.Euler(0, finalrotation, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetrotation, turningspeed * Time.deltaTime);
        
        // 檢查是否旋轉完成
        if (isRotating && Quaternion.Angle(transform.rotation, targetrotation) < 0.1f)
        {
            transform.rotation = targetrotation; // 確保精準對齊
            isRotating = false;
        }
    }
}