using UnityEngine;

public class CanvasRotateToCamera : MonoBehaviour
{
    private Camera targetCamera;
    public bool reverseForward = true;

    private void Awake()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;
    }

    private void LateUpdate()
    {
        if (targetCamera == null)
            return;

        if (reverseForward)
            transform.forward = transform.position - targetCamera.transform.position;
        else
            transform.forward = targetCamera.transform.forward;
    }
}