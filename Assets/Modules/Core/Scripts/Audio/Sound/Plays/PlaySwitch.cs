using UnityEngine;
using UnityEngine.UI;

public class PlaySwitch : MonoBehaviour
{
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        SoundManager.Instance.Play("switch");
    }
}
