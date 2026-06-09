using UnityEngine;
using UnityEngine.UI;

public class MobileCanvasScaler : MonoBehaviour
{
    private CanvasScaler canvasScaler;

    public Vector2 horizontalScale = new Vector3(2200f, 600f);
    public Vector2 verticalScale = new Vector3(800f, 600f);

    void Awake()
    {
        canvasScaler = GetComponent<CanvasScaler>();
    }

    void Update()
    {
        if (canvasScaler == null) return;

        if (Screen.width < Screen.height)
            canvasScaler.referenceResolution = verticalScale;
        else
            canvasScaler.referenceResolution = horizontalScale;
    }
}
