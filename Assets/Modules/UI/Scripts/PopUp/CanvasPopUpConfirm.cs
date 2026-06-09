using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CanvasPopUpConfirm : MonoBehaviour
{
    public TextMeshProUGUI textTitle;
    public TextMeshProUGUI textMessage;
    public TextMeshProUGUI textButtonConfirm;
    public TextMeshProUGUI textButtonDecline;

    public Action onConfirm;
    public Action onDecline;

    public void Set(string title, string message)
    {
        textTitle.text = title;
        textMessage.text = message;
    }

    public void SetButtonText(string confrim, string decline)
    {
        textButtonConfirm.text = confrim;
        textButtonDecline.text = decline;
    }

    public void OnConfirm()
    {
        onConfirm?.Invoke();
    }


    public void OnDecline()
    {
        onDecline?.Invoke();
    }
}
