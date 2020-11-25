using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Mouse = UnityEngine.InputSystem.Mouse;

// This may be used later. Currently using basic Input System UI Input Module

public class InputManager : MonoBehaviour, IPointerClickHandler
{
    private Mouse mouse = Mouse.current;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
    }

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    private void Update()
    {

        if (Touch.activeFingers.Count == 1)
        {
            Touch activeTouch = Touch.activeFingers[0].currentTouch;

            Debug.Log($"Phase: {activeTouch.phase} | Position: {activeTouch.startScreenPosition}");
        }
    }
}
