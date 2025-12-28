using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonDelay : MonoBehaviour
{
    public Button targetButton;
    public float delayTime = 5f;
    public GameObject teachUI;

    private void Start()
    {
        if (targetButton != null)
        {
            targetButton.interactable = false;
        }
    }

    // 當 teachUI 顯示時呼叫這個
    public void StartButtonDelay()
    {
        if (targetButton != null)
        {
            targetButton.interactable = false;
            StartCoroutine(EnableButtonAfterDelay());
        }
    }

    IEnumerator EnableButtonAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        
        if (targetButton != null)
        {
            targetButton.interactable = true;
        }
    }

    public void CloseTeachUI()
    {
        teachUI.SetActive(false);
    }
}