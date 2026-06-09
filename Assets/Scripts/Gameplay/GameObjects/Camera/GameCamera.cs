using UnityEngine;
using UnityEngine.UI;

public class GameCamera : Static<GameCamera>
{
    private Camera camera;
    public ButtonTrigger buttonZoom;

    public float fovDefault = 55;
    public float fovZoomOut = 90;

    [Space]
    public float fovTarget = 55;
    public float fovCurrent = 55;

    [Space]
    public float speed = 20;

    protected override void Awake()
    {
        base.Awake();

        camera = GetComponent<Camera>();
        buttonZoom.onIsPressedChange += OnIsPressedChange;

        fovTarget = fovDefault;
        fovCurrent = fovDefault;
    }

    void OnDestroy()
    {
        if (buttonZoom != null)
            buttonZoom.onIsPressedChange -= OnIsPressedChange;
    }

    void Update()
    {
        ApplyFov();
    }

    public void ApplyFov()
    {
        fovCurrent = Mathf.MoveTowards(fovCurrent, fovTarget, Time.deltaTime * speed);

        if (camera.fieldOfView != fovCurrent)
            camera.fieldOfView = fovCurrent;
    }

    public void OnIsPressedChange()
    {
        if (buttonZoom.IsPressed)
            fovTarget = fovZoomOut;
        else
            fovTarget = fovDefault;
    }
}
