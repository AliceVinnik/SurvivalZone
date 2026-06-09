using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler,
                                IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public event Action onDown;
    public event Action onUp;
    public event Action onClick;
    public event Action onEnter;
    public event Action onExit;
    public event Action onSelect;
    public event Action onDeselect;

    public event Action onIsPressedChange;
    public event Action onIsHoveredChange;
    public event Action onIsSelectedChange;

    public bool IsPressed { get; private set; }
    public bool IsHovered { get; private set; }
    public bool IsSelected { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressed = true;
        onDown?.Invoke();
        onIsPressedChange?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressed = false;
        onUp?.Invoke();
        onIsPressedChange?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsHovered = true;
        onEnter?.Invoke();
        onIsHoveredChange?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsHovered = false;
        onExit?.Invoke();
        onIsHoveredChange?.Invoke();
    }

    public void OnSelect(BaseEventData eventData)
    {
        IsSelected = true;
        onSelect?.Invoke();
        onIsSelectedChange?.Invoke();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        IsSelected = false;
        onDeselect?.Invoke();
        onIsSelectedChange?.Invoke();
    }

    private void OnDisable()
    {
        IsPressed = false;
        IsHovered = false;
        IsSelected = false;
        onIsPressedChange?.Invoke();
        onIsHoveredChange?.Invoke();
        onIsSelectedChange?.Invoke();
    }
}