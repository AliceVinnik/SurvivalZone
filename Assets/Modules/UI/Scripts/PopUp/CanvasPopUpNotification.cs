using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CanvasPopUpNotification : MonoBehaviour
{
    public TextMeshProUGUI textTitle;
    public TextMeshProUGUI textMessage;
    public TextMeshProUGUI textButtonConfirm;

    public Action onConfirm;

    public void Set(string title, string message)
    {
        textTitle.text = title;
        textMessage.text = message;
    }

    public void SetButtonText(string confrim)
    {
        textButtonConfirm.text = confrim;
    }

    public void OnConfirm()
    {
        onConfirm?.Invoke();
    }
}
