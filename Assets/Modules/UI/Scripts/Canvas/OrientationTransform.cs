using UnityEngine;
using UnityEngine.UI;

public class MobileCanvasTransform : MonoBehaviour
{
    [Space]
    public Vector3 horizontalPosition = new Vector3(0f, 0f, 0f);
    public Vector3 horizontalScale = new Vector3(1f, 1f, 1f);

    [Space]
    public Vector3 verticalPosition = new Vector3(0f, 0f, 0f);
    public Vector3 verticalScale = new Vector3(1f, 1f, 1f);

    void Awake()
    {
    }

    void Update()
    {
        if (Screen.width < Screen.height)
        {
            transform.localScale = verticalScale;
            transform.localPosition = verticalPosition;
        }
        else
        {
            transform.localScale = horizontalScale;
            transform.localPosition = horizontalPosition;
        }
    }
}
