using UnityEngine;
using UnityEngine.UI;

public class PlayButtonClick : MonoBehaviour
{
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        SoundManager.Instance.Play("buttonClick");
    }
}
