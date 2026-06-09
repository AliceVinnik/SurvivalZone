/*AliceVinnik*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSwipe : MonoBehaviour
{
    private Vector3 inputPositionFirst;
    private Vector3 inputPositionSecond;
    private float inputDragDistance;
    private bool inputPossible;
    private float inputTimer;
    private float inputTimerDefault = 0.5f;

    public bool isKeyInputActive = true;

    public Action onSwipeUp;
    public Action onSwipeDown;
    public Action onSwipeLeft;
    public Action onSwipeRight;
    public Action onTap;

    void Start()
    {
        CalculateInputSwipeValues();
    }

    void Update()
    {
        Process();
    }

    private void Process()
    {
        if (Input.touchCount == 1)
        {
            //Process input
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                inputPossible = true;
                inputTimer = inputTimerDefault;
                inputPositionFirst = touch.position;
                inputPositionSecond = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended && inputPossible)
            {
                inputPositionSecond = touch.position;

                if (Mathf.Abs(inputPositionSecond.x - inputPositionFirst.x) > inputDragDistance || Mathf.Abs(inputPositionSecond.y - inputPositionFirst.y) > inputDragDistance)
                {
                    if (Mathf.Abs(inputPositionSecond.x - inputPositionFirst.x) > Mathf.Abs(inputPositionSecond.y - inputPositionFirst.y))
                    {
                        if ((inputPositionSecond.x > inputPositionFirst.x)) onSwipeRight?.Invoke();
                        else onSwipeLeft?.Invoke();
                    }
                    else
                    {
                        if (inputPositionSecond.y > inputPositionFirst.y) onSwipeUp?.Invoke();
                        else onSwipeDown?.Invoke();
                    }
                }
                else
                    onTap?.Invoke();
            }

            //Timer countdown
            inputTimer -= Time.deltaTime;
            if (inputTimer <= 0.0f)
            {
                inputTimer = 0.0f;
                inputPossible = false;
            }
        }

        if (isKeyInputActive)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) onSwipeUp?.Invoke();
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) onSwipeDown?.Invoke();
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) onSwipeLeft?.Invoke();
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) onSwipeRight?.Invoke();
        }
    }

    private void CalculateInputSwipeValues()
    {
        inputDragDistance = Screen.width * 15 / 100;
    }
}