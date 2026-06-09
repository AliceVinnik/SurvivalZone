/*AliceVinnik*/

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static JoyStick instance;

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasScaler canvasScaler;
    public GameObject stick;

    public enum State { Wait, Active }

    public bool moveBackInstant = false;
    public float moveBackSpeed = 5f;
    [HideInInspector] public State state = State.Wait;

    private Vector2 inputPosition = Vector2.zero;
    private float diameter = 0f;
    private int trackedFingerId = -1;

    #region System

    private void Awake()
    {
        instance = this;
        canvas = FindCanvasRecursively(transform);
        canvasScaler = canvas.GetComponent<CanvasScaler>();
        rectTransform = GetComponent<RectTransform>();
        diameter = rectTransform.sizeDelta.x / 2f;
        state = State.Wait;

        EnhancedTouchSupport.Enable();
    }

    private Canvas FindCanvasRecursively(Transform t)
    {
        if (t == null) return null;

        var canvas = t.GetComponent<Canvas>();
        if (canvas != null) return canvas;

        return FindCanvasRecursively(t.parent);
    }

    private void OnDestroy()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        if (state == State.Active)
            TrackInput();

        MoveToFinger();
        MoveBack();
    }

    #endregion

    #region Usage

    public Vector2 GetInput()
    {
        var x = Mathf.Clamp(1f / diameter * stick.transform.localPosition.x, -1f, 1f);
        var y = Mathf.Clamp(1f / diameter * stick.transform.localPosition.y, -1f, 1f);
        return new Vector2(x, y);
    }

    public float GetAngle()
    {
        return -GetAngleFrom(Vector2.zero,
            new Vector2(stick.transform.localPosition.x, stick.transform.localPosition.y)) + 90f;
    }

    public bool IsActive() => state == State.Active;

    public void Deactivate()
    {
        state = State.Wait;
        trackedFingerId = -1;
        stick.transform.localPosition = Vector3.zero;
    }

    #endregion

    #region Pointer Events

    public void OnPointerDown(PointerEventData eventData)
    {
        state = State.Active;
        trackedFingerId = eventData.pointerId;
        SetInput(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == trackedFingerId)
            Deactivate();
    }

    #endregion

    #region Input Tracking

    /// <summary>
    /// Called each frame while active — polls the tracked finger or mouse.
    /// </summary>
    private void TrackInput()
    {
        // Try active touches first (Enhanced Touch API)
        if (Touch.activeTouches.Count > 0)
        {
            foreach (var touch in Touch.activeTouches)
            {
                // Match by finger ID if we have one, otherwise take first touch
                if (trackedFingerId < 0 || touch.finger.index == trackedFingerId)
                {
                    SetInput(touch.screenPosition);
                    return;
                }
            }
        }

        // Fall back to Mouse (editor / standalone)
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            SetInput(Mouse.current.position.ReadValue());
        }
    }

    private void SetInput(Vector2 screenPos)
    {
        var centerPoint = new Vector2(rectTransform.position.x, rectTransform.position.y);
        var offset = screenPos - centerPoint;
        inputPosition = centerPoint + Vector2.ClampMagnitude(offset, diameter);
    }

    private void MoveToFinger()
    {
        if (state != State.Active) return;
        stick.transform.position = inputPosition;
    }

    private void MoveBack()
    {
        if (state != State.Wait) return;

        if (moveBackInstant)
            stick.transform.localPosition = Vector2.zero;
        else
            stick.transform.localPosition = Vector2.MoveTowards(
                stick.transform.localPosition,
                Vector2.zero,
                Time.fixedDeltaTime * moveBackSpeed);
    }

    #endregion

    public float GetAngleFrom(Vector2 me, Vector2 target)
    {
        return (float)(Math.Atan2(target.y - me.y, target.x - me.x) * (180 / Math.PI));
    }
}