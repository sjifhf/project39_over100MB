using UnityEngine;

public class Control_ViewType : MonoBehaviour
{
    [Header("Movement")]
    public PlayerMovement_3D playerMovement_3D;
    public PlayerMovement_2D playerMovement_2D;

    [Header("Rotation / Camera")]
    public rotationchanging rotationScript;
    public MouseLook mouseLook;

    [Header("Cameras")]
    public Camera camera3D; // 第一人稱相機
    public Camera camera2D; // 第三人稱相機

    public enum ViewType { View2D, View3D }
    public ViewType currentView = ViewType.View3D;

    void Start()
    {
        SwitchTo3D();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentView == ViewType.View3D)
                SwitchTo2D();
            else
                SwitchTo3D();
        }
    }

    void SwitchTo2D()
    {
        currentView = ViewType.View2D;

        playerMovement_3D.enabled = false;
        playerMovement_2D.enabled = true;

        rotationScript.enabled = true;
        mouseLook.SetLookEnabled(false);

        // 切換相機
        if (camera3D != null) camera3D.enabled = false;
        if (camera2D != null) camera2D.enabled = true;

        Debug.Log("切換到 2D 視角");
    }

    void SwitchTo3D()
    {
        currentView = ViewType.View3D;

        playerMovement_3D.enabled = true;
        playerMovement_2D.enabled = false;

        rotationScript.enabled = false;
        mouseLook.SetLookEnabled(true);

        // 切換相機
        if (camera2D != null) camera2D.enabled = false;
        if (camera3D != null) camera3D.enabled = true;

        Debug.Log("切換到 3D 視角");
    }
}