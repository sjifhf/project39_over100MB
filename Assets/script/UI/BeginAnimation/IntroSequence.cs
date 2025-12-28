using UnityEngine;
using System.Collections;

public class IntroSequence : MonoBehaviour
{
    public EyeOpenUI eyeUI;
    public IntroLookAround lookScript;
    
    [Header("要禁用的腳本")]
    public MonoBehaviour playerControl;
    public MouseLook mouseLook;
    public Control_ViewType viewTypeControl; // 加這個！

    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        // 禁用移動、視角和切換
        playerControl.enabled = false;
        mouseLook.enabled = false;
        if (viewTypeControl != null)
            viewTypeControl.enabled = false;

        yield return eyeUI.OpenEyes();
        yield return lookScript.LookAround();

        // 恢復控制
        playerControl.enabled = true;
        mouseLook.enabled = true;
        if (viewTypeControl != null)
            viewTypeControl.enabled = true;
    }
}